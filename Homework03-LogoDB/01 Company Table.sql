USE [LogoDB]
GO

/* Veritabanýnda oluþturulan Company tablosunun scripti */
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCompany](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[NameShort] [nvarchar](100) NOT NULL,
	[Mail] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](1000) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Descriptions] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblCompany] ADD  CONSTRAINT [DF_Company_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[tblCompany] ADD  CONSTRAINT [DF_Table_1_Surname]  DEFAULT ('') FOR [NameShort]
GO

ALTER TABLE [dbo].[tblCompany] ADD  CONSTRAINT [DF_Company_Mail]  DEFAULT ('') FOR [Mail]
GO

ALTER TABLE [dbo].[tblCompany] ADD  CONSTRAINT [DF_Company_Address]  DEFAULT ('') FOR [Address]
GO

ALTER TABLE [dbo].[tblCompany] ADD  CONSTRAINT [DF_Company_Phone]  DEFAULT ('') FOR [Phone]
GO

ALTER TABLE [dbo].[tblCompany] ADD  CONSTRAINT [DF_Company_Descriptions]  DEFAULT ('') FOR [Descriptions]
GO

ALTER TABLE [dbo].[tblCompany] ADD  CONSTRAINT [DF_Company_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[tblCompany] ADD  CONSTRAINT [DF_Company_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

/*User tablosu ile 1 e 1 iliþki*/
ALTER TABLE [dbo].[tblCompany]  WITH CHECK ADD  CONSTRAINT [FK_tblCompany_tblUser] FOREIGN KEY([Id])
REFERENCES [dbo].[tblUser] ([Id])
GO

ALTER TABLE [dbo].[tblCompany] CHECK CONSTRAINT [FK_tblCompany_tblUser]
GO


