USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertResourcePlanner]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertResourcePlanner]
	@EMP_ID int ,
	--@EMPLOYEE_NAME varchar(50),
	@DATE_ENTRY DATETIME ,
	@STATUS int 

AS
DECLARE @COUNT FLOAT
IF @STATUS = 3 OR @STATUS = 4 OR @STATUS = 8 OR @STATUS = 10
	SET @COUNT = 1
ELSE 
	SET @COUNT = 0.5

INSERT into [dbo].[RESOURCE_PLANNER]
VALUES
(
	@EMP_ID,
	--@EMPLOYEE_NAME,
	@DATE_ENTRY,
	@STATUS,
	@COUNT
)

GO
