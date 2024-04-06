﻿CREATE PROC FI_SP_AltBeneficiario
    @NOME          VARCHAR (50) ,
    @CPF           VARCHAR (9)  ,
	@IdCliente           BIGINT,
	@Id           BIGINT
AS
BEGIN
	UPDATE CLIENTES 
	SET 
		NOME = @NOME,  
		CPF = @CPF, 
		IdCliente = @CPF
	WHERE Id = @Id
END