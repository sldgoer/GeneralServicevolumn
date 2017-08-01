CREATE TABLE [dbo].[BlackList] (
    [id]      INT          IDENTITY (1, 1) NOT NULL,
    [idcard]  VARCHAR (20) NOT NULL,
    [state]   INT          NOT NULL,
    [addtime] DATETIME     NOT NULL,
    CONSTRAINT [PK_BlackList] PRIMARY KEY CLUSTERED ([id] ASC)
);

