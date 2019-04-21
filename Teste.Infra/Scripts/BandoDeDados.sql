USE master

IF (SELECT Count(*) FROM sys.databases WHERE name = 'Teste') > 0
	Drop DATABASE Teste
GO
CREATE DATABASE Teste
GO

USE Teste
GO

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TB_ContaCorrente'))
	Drop table TB_ContaCorrente
GO
Create table TB_ContaCorrente
(
    numero int primary key,
    saldo decimal not null
)
GO 

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TB_Lancamento'))
	Drop table TB_Lancamento
GO
Create table TB_Lancamento
(
    id int identity(1,1) primary key,
	numeroConta int not null,
    tipo int not null,
	[data] Datetime not null,
	valor decimal not null,
	CONSTRAINT FK_TB_Lancamento_TB_ContaCorrente FOREIGN KEY (numeroConta)     
    REFERENCES TB_ContaCorrente (numero)      
)
GO 

insert into TB_ContaCorrente values (1,200)
insert into TB_ContaCorrente values (2,300)
insert into TB_ContaCorrente values (3,500)

go
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TB_Cliente'))
	Drop table TB_Cliente
GO
Create table TB_Cliente
(
 	CPF varchar(20) primary key,
    senha varchar(20)
)
GO 

insert into TB_Cliente values('1234','1234')

