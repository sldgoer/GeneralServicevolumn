CREATE TABLE [dbo].[BookingLeft] (
    [id]        INT          IDENTITY (1, 1) NOT NULL,
    [name]      VARCHAR (50) NOT NULL,
    [beginTime] VARCHAR (5)  NOT NULL,
    [endTime]   VARCHAR (5)  NOT NULL,
    [date]      DATETIME     NOT NULL,
    [leftNum]   INT          NOT NULL,
    [areaCode]  INT          NOT NULL,
    CONSTRAINT [PK_BookingLeft] PRIMARY KEY CLUSTERED ([id] ASC)
);

