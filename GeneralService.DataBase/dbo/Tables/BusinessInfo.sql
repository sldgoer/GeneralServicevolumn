CREATE TABLE [dbo].[BusinessInfo] (
    [serial] UNIQUEIDENTIFIER CONSTRAINT [DF_BusinessInfo_serial] DEFAULT (newid()) NOT NULL,
    [name]   VARCHAR (50)     NULL,
    CONSTRAINT [PK_BusinessInfo] PRIMARY KEY CLUSTERED ([serial] ASC)
);

