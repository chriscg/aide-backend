USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAssignedProjects]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateAssignedProjects]
	@EMP_ID int,
	@PROJ_ID int,
	@DATE_CREATED datetime,
	@START_PERIOD datetime,
	@END_PERIOD datetime

AS

UPDATE [dbo].[ASSIGNED_PROJECTS]
SET
	[EMP_ID] = @EMP_ID,
	[PROJ_ID] = @PROJ_ID,
	[DATE_CREATED] = @DATE_CREATED,
	[START_PERIOD] = @START_PERIOD,
	[END_PERIOD] = @END_PERIOD
 WHERE 
	[EMP_ID] = @EMP_ID AND 
	[PROJ_ID] = @PROJ_ID



GO
