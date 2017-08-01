CREATE TABLE [dbo].[SpecialDay] (
    [id]        INT      IDENTITY (1, 1) NOT NULL,
    [date]      DATETIME NOT NULL,
    [isWorkDay] BIT      NOT NULL,
    CONSTRAINT [PK_SpecialDay] PRIMARY KEY CLUSTERED ([id] ASC)
);

