CREATE TABLE [dbo].[NotaFiscal] (
    [numeroNf]           INT              IDENTITY (1, 1) NOT NULL,
    [valorTotal]         DECIMAL (15, 10) NOT NULL,
    [dataNf]             DATETIME2 (7)    NOT NULL,
    [cnpjEmissorNf]      VARCHAR (50)     NOT NULL,
    [cnpjDestinatarioNf] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_NotaFiscal] PRIMARY KEY CLUSTERED ([numeroNf] ASC)
);

