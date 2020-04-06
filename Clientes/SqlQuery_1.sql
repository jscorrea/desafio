Create Table Clientes(
ClienteId Int Identity(1,1) Primary Key,
Nome Varchar(100) Not Null,
Email Varchar(100),
Logotipo Varchar(20),
CONSTRAINT UC_Cliente UNIQUE (Email))
GO
Create Table Logradouros(
LogradouroId Int Identity(1,1) Not null Primary Key,
Logradouro Varchar(200) Not null,
ClienteId int FOREIGN KEY REFERENCES Clientes(ClienteId))
GO
Create Table Usuarios(
UserId Int Identity(1,1) Not null Primary Key,
Email Varchar(50) Not null,
Password Varchar(20) Not null)
GO
Insert Into Usuarios(Email, Password) 
Values ('test@th.com', '$admin@2020')
GO
INSERT INTO [dbo].[Clientes]
           ([Nome]
           ,[Email]
           ,[Logotipo]       
           )
     VALUES
           ('Joao Correa'
           ,'jscorrea2@gmail.com'
           ,'TESTE'         
           )
INSERT INTO [dbo].[Logradouros]
           ([Logradouro]
           ,[ClienteId])
     VALUES
           ('Rua Teste, 288'
           ,1)

INSERT INTO [dbo].[Logradouros]
           ([Logradouro]
           ,[ClienteId])
     VALUES
           ('Rua Tesye, 566'
           ,1)