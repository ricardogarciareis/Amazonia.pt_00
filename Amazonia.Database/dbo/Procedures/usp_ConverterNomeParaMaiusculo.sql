CREATE PROCEDURE [dbo].[usp_ConverterNomeParaMaiusculo]
	@param01 VARCHAR(50)
AS
	SELECT UPPER(@param01)
	--Oi mundo
	--Teste para ver no DB
RETURN 0
