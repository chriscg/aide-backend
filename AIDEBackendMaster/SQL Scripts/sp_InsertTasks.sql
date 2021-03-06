USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTasks]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertTasks] 
			@TASK_ID INT, 
			@EMP_ID INT, 
			@INC_ID VARCHAR(8), 
			@TASK_TYPE SMALLINT, 
			@PROJ_ID INT, 
			@INC_DESCR VARCHAR(MAX), 
			@TASK_DESCR VARCHAR(MAX),
			@DATE_STARTED DATE, 
			@TARGET_DATE DATE, 
			@COMPLTD_DATE DATE, 
			@DATE_CREATED DATE,  
			@STATUS SMALLINT, 
			@REMARKS VARCHAR(50),
			@EFFORT_EST FLOAT, 
			@ACT_EFFORT_EST FLOAT, 
			@ACT_EFFORT_EST_WK FLOAT, 
			@PROJECT_CODE INT, 
			@REWORK TINYINT, 
			@PHASE VARCHAR(20)

AS

SET NOCOUNT ON

INSERT INTO TASKS
           (
		   [TASK_ID],
		   [EMP_ID],--
		   [INC_ID],--
		   [TASK_TYPE],--
		   [PROJ_ID],--
		   [INC_DESCR],--
		   [TASK_DESCR],--
		   [DATE_STARTED],--
		   [TARGET_DATE],--
		   [COMPLTD_DATE],--
		   [DATE_CREATED],--
		   [STATUS],--
		   [REMARKS],--
		   [EFFORT_EST],--
		   [ACT_EFFORT_EST],--
		   [ACT_EFFORT_EST_WK],--
		   [PROJECT_CODE],--
		   [REWORK],
		   [PHASE] 
		   )
     VALUES
           (
		   @TASK_ID,
		   @EMP_ID,
		   @INC_ID,
		   @TASK_TYPE,
		   @PROJ_ID,
		   @INC_DESCR,
		   @TASK_DESCR,
		   @DATE_STARTED,
		   @TARGET_DATE,
		   @COMPLTD_DATE,
		   @DATE_CREATED,
		   @STATUS,
		   @REMARKS,
		   @EFFORT_EST,
		   @ACT_EFFORT_EST,
		   @ACT_EFFORT_EST_WK,
		   @PROJECT_CODE,
		   @REWORK,
		   @PHASE
		   
		   );



GO
