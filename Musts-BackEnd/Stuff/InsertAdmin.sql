select * from UserRols
select * from Users
select * from Authorizations
select * from Rols_Authorizations

INSERT INTO UserRols
([Name])
VALUES
('Administrador'),
('Operario')

INSERT INTO Users
(IdRol, UserName, InsertDate, UpdateDate, IsActive, EncryptedPassword, EncryptedToken, TokenExpireDate, FailedConsecutiveLogins)
VALUES
(1, 'chotsourian.marcos@gmail.com', GETDATE(), GETDATE(), 1, '$2a$11$Q8Nbi1KlVJwmXgDNf2AZwOWa6/VRM.lqIukpovD7EEHhsI/dP335i', '', GETDATE(), 0)
--la pass es sasasa10000

INSERT INTO Authorizations
(ControllerName, ActionName, HTTPMethodType, InsertDate)
VALUES
('user', 'insertuser', 'POST', GETDATE())

INSERT INTO Rols_Authorizations
(IdRol, IdAuthorization, IsActive)
VALUES
(1, 1, 1)

--IdWeb
--Convenciones y buenos nombres de tablas, columnas y eso
--Ok que hay cosas que puede hacerse mejor, pero para que lo puedan pensar y comprender
--pensar muy bien qué recursos mínimos, medios y bonuses les doy. qué está bien hecho y qué no tanto y qué para nada, etcs.