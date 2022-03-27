USE [LogoDB]
GO

/* Veritabanýnda oluþturulan User tablosunun scripti */ 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](1000) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_User_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_User_Surname]  DEFAULT ('') FOR [Surname]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_User_Mail]  DEFAULT ('') FOR [Mail]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_User_Password]  DEFAULT ('') FOR [Password]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_User_Address]  DEFAULT ('') FOR [Address]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_User_Phone]  DEFAULT ('') FOR [Phone]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_User_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_User_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO


