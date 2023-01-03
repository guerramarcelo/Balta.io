using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT 
                    [User].*,
                    [Role].*
                FROM
                    [User] 
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id] 
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);
                    return user;

                }, splitOn: "Id");

            return users;
        }

        public User CreateUser(User user)
        {
            var parameters = new
            {
                @Name = user.Name,
                @Email = user.Email,
                @PasswordHash = user.PasswordHash,
                @Bio = user.Bio,
                @Image = user.Image,
                @Slug = user.Slug
            };
            _connection.Execute("spCreateUser", parameters, commandType: CommandType.StoredProcedure);
            return user;
        }
        public Role CreateRole(Role role)
        {
            var sql = "INSERT INTO [Role] ([Name], [Slug]) VALUES (@name, @slug)";
            _connection.Query<Role>(sql, new
            {
                Name = role.Name,
                Slug = role.Slug,
            });

            return role;
        }
        public void CreateUserRole(int id, int roleId)
        {
            var sql = "spCreateUserRole";
            var parameters = new
            {
                @UserId = id,
                @RoleId = roleId,
            };
            var items = _connection.Execute(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void GetWithRoleById()
        {
            var sql = @"
                SELECT 
                    [User].*                       
                FROM [User]
                INNER JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]                 
                WHERE [UserRole].[UserId] = 1"; // <-

            var users = _connection.Query<User>(sql);

            var stringBuilder = new StringBuilder();
            foreach (var user in users)
            {
                stringBuilder.AppendLine("---------------");
                stringBuilder.AppendLine($"Id - {user.Id}");
                stringBuilder.AppendLine($"Name - {user.Name}");
                stringBuilder.AppendLine($"Email - {user.Email}");
                stringBuilder.AppendLine($"PasswordHash - {user.PasswordHash}");
                stringBuilder.AppendLine($"Bio - {user.Bio}");
                stringBuilder.AppendLine($"Image - {user.Image}");
                stringBuilder.AppendLine($"Slug - {user.Slug}");
                stringBuilder.AppendLine($"--------------");
            }

            var sql2 = @"
                SELECT 
                    [Role].*
                FROM [Role]
                INNER JOIN [UserRole] ON [UserRole].[RoleId] = [Role].[Id]                 
                WHERE [UserRole].[RoleId] = 1"; //<-
            var roles = _connection.Query<Role>(sql2);

            foreach (var role in roles)
            {
                stringBuilder.AppendLine($"RoleId - {role.Id}");
                stringBuilder.AppendLine($"Name - {role.Name}");
                stringBuilder.AppendLine($"Slug - {role.Slug}");
            }
            Console.WriteLine(stringBuilder.ToString());

            //Antes do StringBuilder

            //{
            //DapperRow, Id = '1',
            //Name = 'André Baltieri',
            //Email = 'andre@balta.io',
            //PasswordHash = 'HASH',
            //Bio = '8x Microsoft MVP',
            //Image = 'https://',
            //Slug = 'andre-baltieri',
            //RoleId = '1',
            //RoleName = 'Author',
            //RoleSlug = 'author'
            //}

            // Depois do StringBuilder

            //---------------
            //Id - 1
            //Name - André Baltieri
            //Email - andre@balta.io
            //PasswordHash - HASH
            //Bio - 8x Microsoft MVP
            //Image - https://
            //Slug - andre - baltieri
            //--------------
            //RoleId - 1
            //Name - Author
            //Slug - author
        }
    }
}

