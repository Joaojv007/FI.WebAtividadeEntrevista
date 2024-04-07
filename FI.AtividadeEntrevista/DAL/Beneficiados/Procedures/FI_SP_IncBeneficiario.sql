﻿CREATE PROC FI_SP_IncBeneficiarioV2
    @NOME          VARCHAR (50) ,
    @CPF           VARCHAR (14)  ,
    @IDCLIENTE     BIGINT (2)
AS
BEGIN
	INSERT INTO CLIENTES (NOME, CPF, IDCLIENTE) 
	VALUES (@NOME, @CPF, @IDCLIENTE)

	SELECT SCOPE_IDENTITY()
END