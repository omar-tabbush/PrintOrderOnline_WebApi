CREATE TABLE [dbo].[DocumentFiles] (
    [DocumentFileID]   INT             IDENTITY (1, 1) NOT NULL,
    [DocumentFileName] VARCHAR (30)    DEFAULT ('null') NOT NULL,
    [UploadDate]       DATETIME        NULL,
    [FileSize]         BIGINT          NULL,
    [FileData]         VARBINARY (MAX) NULL,
    [FileFormat]       VARCHAR (10)    NULL,
    UNIQUE NONCLUSTERED ([DocumentFileID] ASC)
);

