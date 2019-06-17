USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssignedProjects]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllAssignedProjects]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT DISTINCT A.PROJ_NAME FROM PROJECT A INNER JOIN ASSIGNED_PROJECTS B
	ON A.PROJ_ID = B.PROJ_ID
	
END

GO
