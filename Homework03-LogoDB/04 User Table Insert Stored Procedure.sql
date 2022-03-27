USE [LogoDB]
GO
/* Veritabanýnda oluþturulan user tablosuna kayýt ekleyen insert stored procerude scripti */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER PROCEDURE [dbo].[spUser_insert]
	  @Name nvarchar(100)
      ,@Surname nvarchar(50)
      ,@Mail nvarchar(250)
      ,@Password nvarchar(MAX)
      ,@Address nvarchar(1000)
      ,@Phone nvarchar(50)
      --,@CompanyId int
      ,@DateCreated datetime2(7)
      ,@IsActive bit
	  ,@Result bit out
	  ,@ErrorMessage varchar(max) out
AS
BEGIN
	SET NOCOUNT ON;
	SET @Result = 1;
	SET @ErrorMessage = '';
	
	IF((select count(Id) from tblUser where Mail = @Mail)>0)
	BEGIN
		SET @Result = 0;
		SET @ErrorMessage = @Mail + ' Mail adresi ile daha önce kayýt yapýlmýþ. Bu mail adresi ile tekrar kayýt yapýlamaz.';
	END
	ELSE
	BEGIN

    insert into dbo.tblUser
	([Name]
      ,[Surname]
      ,[Mail]
      ,[Password]
      ,[Address]
      ,[Phone]
      --,[CompanyId]
      ,[DateCreated]
      ,[IsActive])
	  values(
	   @Name 
      ,@Surname  
      ,@Mail  
      ,@Password  
      ,@Address 
      ,@Phone  
      --,@CompanyId  
      ,@DateCreated  
      ,@IsActive  
	  )

	  END
END
