CREATE TABLE [dbo].[BookingRecord] (
    [name]          VARCHAR (50) NOT NULL,
    [frontChar]     VARCHAR (2)  NOT NULL,
    [beginTime]     VARCHAR (5)  NOT NULL,
    [endTime]       VARCHAR (5)  NOT NULL,
    [date]          DATETIME     NOT NULL,
    [bookingSerial] VARCHAR (20) NOT NULL,
    [state]         INT          CONSTRAINT [DF_BookingRecord_state] DEFAULT ((0)) NOT NULL,
    [callPlatform]  VARCHAR (50) NOT NULL,
    [idcard]        VARCHAR (20) NOT NULL,
    [mobile]        VARCHAR (11) NOT NULL,
    [areaCode]      INT          NOT NULL,
    CONSTRAINT [PK_BookingRecord] PRIMARY KEY CLUSTERED ([bookingSerial] ASC)
);

