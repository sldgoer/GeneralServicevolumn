CREATE TABLE [dbo].[Managers] (
    [username] NCHAR (10) NOT NULL,
    [userpwd]  NCHAR (16) NOT NULL,
    CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED ([username] ASC)
);

