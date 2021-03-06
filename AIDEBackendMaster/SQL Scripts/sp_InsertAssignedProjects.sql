USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAssignedProjects]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertAssignedProjects]
	@EMP_ID int ,
	@PROJ_ID int ,
	@DATE_CREATED datetime ,
	@START_PERIOD datetime ,
	@END_PERIOD datetime 

AS

DECLARE @COUNT INT = (SELECT COUNT(EMP_ID) FROM ASSIGNED_PROJECTS 
					  WHERE START_PERIOD BETWEEN @START_PERIOD AND @END_PERIOD 
					  AND END_PERIOD BETWEEN @START_PERIOD AND @END_PERIOD
					  AND PROJ_ID = @PROJ_ID)
IF @COUNT = 0
	BEGIN
		INSERT [dbo].[ASSIGNED_PROJECTS]
		(
			[EMP_ID],
			[PROJ_ID],
			[DATE_CREATED],
			[START_PERIOD],
			[END_PERIOD]
		)
		VALUES
		(
			@EMP_ID,
			@PROJ_ID,
			@DATE_CREATED,
			@START_PERIOD,
			@END_PERIOD

		)
	END
ELSE
	BEGIN
		RAISERROR('Already Assigned Employee for that project', 16, 1)
	END




GO
