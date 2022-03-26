USE [LogoDB]
GO

/* Veritaban�nda olu�turulan Company tablosuna kay�t ekleyen insert stored procerude scripti */
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spCompany_insert]
	  @Name nvarchar(1000)
      ,@NameShort nvarchar(100)
      ,@Mail nvarchar(250)
      ,@Address nvarchar(1000)
      ,@Phone nvarchar(50)
      ,@Descriptions nvarchar(max)
      ,@DateCreated datetime2(7)
      ,@IsActive bit
	  ,@Result bit out
	  ,@ErrorMessage varchar(max) out
AS
BEGIN
	SET NOCOUNT ON;
	SET @Result = 1;
	SET @ErrorMessage = '';
	
	IF((select count(Id) from tblUser where Name = @Name)>0)
	BEGIN
		SET @Result = 0;
		SET @ErrorMessage = @Name + ' isminde daha �nce kay�t yap�lm��. Kar���kl�klara neden olmamak i�in bu isimde ikinci bir kay�t olu�turulamaz.';
	END
	ELSE
	BEGIN

    insert into dbo.tblCompany
	([Name]
      ,NameShort
      ,[Mail]
      ,[Address]
      ,[Phone]
      ,[Descriptions]
      ,[DateCreated]
      ,[IsActive])
	  values(
	   @Name 
      ,@NameShort 
      ,@Mail  
      ,@Address 
      ,@Phone  
      ,@Descriptions
      ,@DateCreated  
      ,@IsActive  
	  )

	  END
END
GO


