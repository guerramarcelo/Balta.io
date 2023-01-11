CREATE OR ALTER PROCEDURE spCreateUser (
    @Name NVARCHAR(80),
    @Email VARCHAR(200),
    @PasswordHash VARCHAR(255),
    @Bio TEXT,
    @Image VARCHAR(2000),
    @Slug VARCHAR(80)
)
AS 
BEGIN TRANSACTION  

INSERT INTO [User]  ([Name], [Email], [PasswordHash], [Bio], [Image], [Slug])

VALUES(@Name, @Email, @PasswordHash, @Bio, @Image, @Slug)

COMMIT