USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAssetHistory]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertAssetHistory] 
	-- Add the parameters for the stored procedure here
	@EMPID int,
	@ASSETID int,
	@STATS int,
	@DATEASSIGNED DATETIME,
	@TABLENAME TEXT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[ASSETS_HISTORY]
	(
			[ASSET_ID],
			[EMP_ID],
			[TABLE_NAME],
			[STATUS],
			[DATE_ASSIGNED]
	)
	VALUES
	(
		@ASSETID,
		@EMPID,
		@TABLENAME,
		@STATS,
		@DATEASSIGNED
	)
END
GO
