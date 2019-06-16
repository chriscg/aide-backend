USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProjectList]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllProjectList]

AS



	 SELECT TOP 1000 
	   [PROJ_ID]
      ,[PROJ_NAME]
      ,[CATEGORY]
      ,[BILLABILITY]
  FROM [AIDE].[dbo].[PROJECT] 


  


GO
