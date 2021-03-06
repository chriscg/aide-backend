USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAssetManufacturer]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAssetManufacturer] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAN_ID AS ASSET_ID,
		   MAN_DESCR  AS MANUFACTURER
	FROM ASSET_MANUFACTURER
END 

GO
