USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_PROJECT_SelectAll]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_PROJECT_SelectAll]
AS

	SELECT 
		[PROJ_ID], [PROJ_CD], [PROJ_NAME], [CATEGORY], [BILLABILITY]
	FROM [dbo].[PROJECT]



GO
