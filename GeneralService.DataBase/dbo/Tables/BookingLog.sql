CREATE TABLE [dbo].[BookingLog] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [type]        VARCHAR (50)   NOT NULL,
    [interface]   VARCHAR (50)   NOT NULL,
    [time]        DATETIME       NOT NULL,
    [description] VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_BookingLog_1] PRIMARY KEY CLUSTERED ([id] ASC)
);

