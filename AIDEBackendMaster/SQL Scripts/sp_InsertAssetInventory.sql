USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAssetInventory]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertAssetInventory]
	-- Add the parameters for the stored procedure here
	@EMP_ID int,
	@ASSET_ID int,
	@STATUS int,
	@DATE_ASSIGNED DATETIME,
	@COMMENTS text

AS

DECLARE @COUNT INT = (SELECT COUNT(ASSET_INVENTORY_ID) FROM ASSETS_INVENTORY WHERE ASSET_ID = @ASSET_ID AND EMP_ID = @EMP_ID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @COUNT <> 0
		BEGIN			
			UPDATE ASSETS_INVENTORY SET EMP_ID = @EMP_ID, STATUS = @STATUS WHERE ASSET_ID = @ASSET_ID
			IF @@ROWCOUNT <> 0
			BEGIN
				UPDATE ASSETS SET STATUS = @STATUS WHERE ASSET_ID = @ASSET_ID
			END
		END
	ELSE
	BEGIN	
		INSERT [dbo].[ASSETS_INVENTORY]
		(
			[EMP_ID],
			[ASSET_ID],
			[STATUS],
			[DATE_ASSIGNED],
			[COMMENTS]
		)
		VALUES
		(
			@EMP_ID,
			@ASSET_ID,
			@STATUS,
			@DATE_ASSIGNED,
			@COMMENTS
		)
	END

	execute [dbo].[sp_InsertAssetInventory]
	@EMPID = @EMP_ID,
	@ASSETID = @ASSET_ID,
	@STATUS = @STATUS,
	@DATEASSIGNED = @DATE_ASSIGNED

END

GO
