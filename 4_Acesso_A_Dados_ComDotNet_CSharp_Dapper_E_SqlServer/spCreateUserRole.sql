CREATE OR ALTER PROCEDURE spCreateUserRole (
    @UserId INT,
    @RoleId INT
)
AS 
BEGIN TRANSACTION
INSERT INTO [UserRole](
    [UserId],
    [RoleId]
)
VALUES(@UserId, @RoleId)
SELECT * FROM [UserRole]
COMMIT
