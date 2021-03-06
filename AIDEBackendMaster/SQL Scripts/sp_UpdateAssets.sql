USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAssets]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateAssets] 
	-- Add the parameters for the stored procedure here
	@ASSET_ID INT,
	@EMP_ID INT,
	@ASSET_DESC varchar(20),
	@MANUFACTURER varchar(20),
	@MODEL_NO varchar(50),
	@SERIAL_NO varchar(50),
	@ASSET_TAG varchar(20),
	@DATE_PURHCASED DATETIME,
	@STATUS int,
	@OTHER_INFO text
AS

DECLARE @GRP_ID INT = (SELECT GRP_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		@DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		@DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @GRP_ID <> 1  -- If USER 
		BEGIN
			UPDATE [dbo].[ASSETS]
			SET [ASSET_DESC] = @ASSET_DESC,
				[MANUFACTURER] = @MANUFACTURER,
				[MODEL_NO] = @MODEL_NO,
				[SERIAL_NO] = @SERIAL_NO,
				[ASSET_TAG] = @ASSET_TAG,
				[DATE_PURCHASED] = @DATE_PURHCASED, 
				[OTHER_INFO] = @OTHER_INFO
			WHERE ASSET_ID = @ASSET_ID AND EMP_ID = @EMP_ID
		END
	
	ELSE IF @GRP_ID = 1 -- IF MANAGER
		BEGIN
			UPDATE [dbo].[ASSETS]
			SET [ASSET_DESC] = @ASSET_DESC,
				[MANUFACTURER] = @MANUFACTURER,
				[MODEL_NO] = @MODEL_NO,
				[SERIAL_NO] = @SERIAL_NO,
				[ASSET_TAG] = @ASSET_TAG,
				[DATE_PURCHASED] = @DATE_PURHCASED, 
				[OTHER_INFO] = @OTHER_INFO
			WHERE ASSET_ID = @ASSET_ID
		END
	
	DECLARE @DATE DATETIME= GETDATE()

	EXEC sp_InsertAssetHistory
		 @EMPID = @EMP_ID,
		 @ASSETID = @ASSET_ID,
		 @STATS = 4,
		 @DATEASSIGNED = @DATE,
		 @TABLENAME = N'ASSETS'
END

GO
