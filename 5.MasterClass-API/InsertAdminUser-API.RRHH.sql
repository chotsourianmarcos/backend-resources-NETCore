--INGRESO AL ADMIN POR BASE DE DATOS

INSERT INTO Persons
(IdWeb, DocumentNumber, [Name], LastName, BirthDay, Adress, OriginCountry, PhoneNumber, EmailAdress, InsertDate, UpdateDate, IsActive)
VALUES
(NEWID(), 12312312, 'Marcos', 'Chotsourian', '1991-06-19 00:00:00', 'Calle Falsa 123', 'Argentina', '01230123', 'asd@asd.com', GETDATE(), GETDATE(), 1)

SELECT * FROM Persons

INSERT INTO UserRols
([Name], [Description], InsertDate, UpdateDate, IsActive)
VALUES
('Administrador', 'Administra todo', GETDATE(), GETDATE(), 1)

SELECT * FROM UserRols

INSERT INTO Users
(IdPerson, IdRol, [Name], [Password], InsertDate, UpdateDate, IsActive)
VALUES
(1, 1, 'marcoschotsourian', 'contrasenia123', GETDATE(), GETDATE(), 1)

SELECT * FROM Users