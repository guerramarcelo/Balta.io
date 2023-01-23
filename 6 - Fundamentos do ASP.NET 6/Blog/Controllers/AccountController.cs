﻿using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Blog.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost ("v1/accounts/")]
        public async Task<IActionResult> Post(
            [FromBody] RegisterViewModel model,
            [FromServices] BlogDataContext context
            )
        {
            if(!ModelState.IsValid) 
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = new User 
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Email.Replace(oldValue:"@", newValue:"-")
                .Replace(oldValue:".", newValue:"-")
            };

            var password = PasswordGenerator.Generate(
                length: 25,
                includeSpecialChars: true,
                upperCase: false); //para gerar a senha inicial, que pode ser alterada

            user.PasswordHash = PasswordHasher.Hash(password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    user = user.Email, password
                }));
            }
            catch (DbUpdateException)
            {
                return StatusCode(
                    400,
                    value: new ResultViewModel<string>
                    ("05x099 - Este E-mail já está cadastrado!"));
            }
            catch
            {
                return StatusCode(
                    500,
                    value: new ResultViewModel<string>
                    ("05X04 - Falha interna no servidor"));
            }
            

        }


        [HttpPost("v1/accounts/login")]
        public IActionResult Login([FromServices]TokenService tokenService)
        {
            var token = tokenService.GenerateToken(null);
            return Ok(token);
        }

        

        
    }
}
