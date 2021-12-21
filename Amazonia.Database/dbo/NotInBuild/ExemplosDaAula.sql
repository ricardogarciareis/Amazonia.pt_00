/****** Script for SelectTopNRows command from SSMS  ******/

--INSERT INTO Telefone (NumeroTelefone, AlunoId) VALUES ('999999999', 1)

--SELECT TOP (1000) [Id]
--      ,[Matricula]
--      ,[Nome]
--      ,[DataNascimento]
--  FROM [EscolaDB].[dbo].[Aluno]

--SELECT *
--FROM Aluno a
--JOIN Telefone t ON t.AlunoId = a.Id


--SELECT UPPER(a.Nome) AS NomeDoAluno, t.NumeroTelefone
--FROM Aluno a
--JOIN Telefone t ON t.AlunoId = a.Id

--INSERT INTO Aluno (Nome, Matricula, DataNascimento) VALUES ('Pedro', '0001236', '2008-01-01')

--SELECT UPPER(a.Nome) AS NomeDoAluno, t.NumeroTelefone
--FROM Aluno a
--LEFT JOIN Telefone t ON t.AlunoId = a.Id


--INSERT INTO Aluno (Nome, Matricula, DataNascimento, Sexo) VALUES ('Pedro', '0001236', '2008-01-01', 'F')
--SELECT * FROM Aluno 

--UPDATE Aluno SET Sexo = 'X' WHERE Sexo IS NULL OR Sexo = ''


ALTER TABLE Telefone ADD Prefixo VARCHAR(5) DEFAULT ('351')
ALTER TABLE Telefone DROP COLUMN Prefixo 


--CREATE
--INSERT INTO Aluno (Matricula, Nome, DataNascimento) VALUES ('0001235', 'Marta', '2009-12-25')
--SET IDENTITY_INSERT Aluno ON/
--INSERT INTO Aluno (Id, Matricula, Nome, DataNascimento) VALUES (12,'0001235', 'Marta', '2009-12-25')

--READ
--SELECT *
--FROM Aluno a
--WHERE a.Nome = 'Maria'
--SELECT * FROM Aluno a WHERE a.Nome = 'PEDRO' AND a.Id = 6

--UPDATE
--BEGIN TRAN
--UPDATE Aluno SET Nome = 'Maria da Silva Corrigido' WHERE Nome = 'Maria'
--COMMIT
--ROLLBACK


--DELETE FROM Aluno 
--TRUNCATE TABLE Aluno 


--TSQL
--SELECT NEWID()
--SELECT GETDATE()
--SELECT @@SERVERNAME
--SELECT UPPER('maria')
--SELECT SUBSTRING('maria', 1, 3)
--SELECT UPPER(SUBSTRING('maria', 1, 3))
--SELECT TOP 10 * FROM Aluno
--SELECT UPPER(a.Nome) FROM Aluno a
--SELECT DATEPART(YEAR, GETDATE())
--SET DATEFORMAT 'YMD'

--DBCC CHECKIDENT(Aluno, RESEED,100)

--TRUNCATE TABLE


SELECT * FROM Aluno a WHERE a.Nome LIKE 'P%'
SELECT * FROM Aluno a WHERE a.Nome LIKE '%A%'