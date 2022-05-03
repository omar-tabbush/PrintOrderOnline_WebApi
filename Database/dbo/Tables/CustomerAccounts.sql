CREATE TABLE [dbo].[CustomerAccounts] (
    [AccountID]       INT           IDENTITY (1, 1) NOT NULL,
    [Username]        VARCHAR (25)  NOT NULL,
    [Password]        VARCHAR (30)  NOT NULL,
    [Fname]           VARCHAR (30)  NOT NULL,
    [Lname]           VARCHAR (30)  NOT NULL,
    [PhoneNumber]     VARCHAR (15)  NOT NULL,
    [Email]           VARCHAR (99)  NOT NULL,
    [Address1]        VARCHAR (120) NOT NULL,
    [Address2]        VARCHAR (120) NULL,
    [Address3]        VARCHAR (120) NULL,
    [CreatedDateTime] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([AccountID] ASC),
    UNIQUE NONCLUSTERED ([AccountID] ASC)
);

