CREATE TABLE [dbo].[BookingSet] (
    [id]        UNIQUEIDENTIFIER CONSTRAINT [DF_BookingSet_id_1] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [name]      VARCHAR (50)     NOT NULL,
    [frontChar] VARCHAR (2)      NOT NULL,
    [beginTime] VARCHAR (5)      NOT NULL,
    [endTime]   VARCHAR (5)      NOT NULL,
    [maxNum]    INT              NOT NULL,
    [areaCode]  INT              NOT NULL,
    CONSTRAINT [PK_BookingSet_1] PRIMARY KEY CLUSTERED ([id] ASC)
);

