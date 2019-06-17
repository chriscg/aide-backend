USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertWeeklyReport]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertWeeklyReport] 
			@WR_RANGE_ID INT, 
			@PROJ_ID INT, 
			@REWORK SMALLINT, 
			@REF_ID VARCHAR(10),
			@SUBJECT VARCHAR(MAX),
			@SEVERITY SMALLINT,
			@INC_TYPE SMALLINT,
			@EMP_ID INT, 
			@PHASE SMALLINT,
			@STATUS SMALLINT, 
			@DATE_STARTED DATE,  
			@DATE_TARGET DATE,  
			@DATE_FINISHED DATE,
			@DATE_CREATED DATE, 
			@EFFORT_EST FLOAT, 
			@ACT_EFFORT FLOAT, 
			@ACT_EFFORT_WK FLOAT, 
			@COMMENTS VARCHAR(MAX),
			@INBOUND_CONTACTS SMALLINT

AS

SET NOCOUNT ON

INSERT INTO WEEKLY_REPORT 
(
	[WR_WEEK_RANGE_ID],
	[WR_PROJ_ID],
	[WR_REWORK],
	[WR_REF_ID],
	[WR_SUBJECT],
	[WR_SEVERITY],
	[WR_INC_TYPE],
	[WR_EMP_ID],
	[WR_PHASE],
	[WR_STATUS],
	[WR_DATE_STARTED],
	[WR_DATE_TARGET],
	[WR_DATE_FINISHED],
	[WR_DATE_CREATED],
	[WR_EFFORT_EST],
	[WR_ACT_EFFORT],
	[WR_ACT_EFFORT_WK],
	[WR_COMMENTS],
	[WR_INBOUND_CONTACTS]
)
VALUES
(
	@WR_RANGE_ID,
	@PROJ_ID,
	@REWORK,
	@REF_ID,
	@SUBJECT,
	@SEVERITY,
	@INC_TYPE,
	@EMP_ID,
	@PHASE,
	@STATUS,
	@DATE_STARTED,
	@DATE_TARGET,
	@DATE_FINISHED,
	@DATE_CREATED,
	@EFFORT_EST,
	@ACT_EFFORT,
	@ACT_EFFORT_WK,
	@COMMENTS,
	@INBOUND_CONTACTS 
);



GO
