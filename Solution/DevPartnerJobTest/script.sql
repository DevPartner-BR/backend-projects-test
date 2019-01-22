-- Lucas Viana did this script for DevPartner Job Test.

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [NotaFiscal] (
    [NotaFiscalId] uniqueidentifier NOT NULL,
    [NumeroNF] bigint NOT NULL IDENTITY,
    [ValorTotal] decimal(18, 2) NOT NULL,
    [DataNF] datetime2 NOT NULL,
    [CNPJEmissorNF] nvarchar(14) NOT NULL,
    [CNPJDestinatarioNF] nvarchar(14) NOT NULL,
    CONSTRAINT [PK_NotaFiscal] PRIMARY KEY ([NotaFiscalId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190122002024_First Migration', N'2.1.1-rtm-30846');

GO
