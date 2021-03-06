USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAssetsInventoryApproval]    Script Date: 06/28/2019 7:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateAssetsInventoryApproval] 
	-- Add the parameters for the stored procedure here
	@ASSET_ID INT,
	@EMP_ID INT,
	@STATUS INT,
	@APPROVAL int
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE [dbo].[ASSETS_INVENTORY]
	SET [APPROVAL] = @APPROVAL,
		[STATUS]=@STATUS
	WHERE ASSET_ID = @ASSET_ID

	UPDATE [dbo].[ASSETS]
	SET [STATUS] = @STATUS
	WHERE [ASSET_ID] = @ASSET_ID
	
	DECLARE @DATE DATETIME= GETDATE()

	EXEC sp_InsertAssetHistory
		 @EMPID = @EMP_ID,
		 @ASSETID = @ASSET_ID,
		 @STATS = @APPROVAL,
		 @DATEASSIGNED = @DATE,
		 @TABLENAME = N'ASSETS_INVENTORY'
END
