USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBillableHoursByWeek]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Author:		Batongbacal, Aevan Camille N. / J.H. Sanchez
-- Create date: Aug. 1, 2018
-- Description:	Get Billable hours per Dept and Div
-- ================================================
CREATE PROCEDURE [dbo].[sp_GetBillableHoursByWeek]
	-- Add the parameters for the stored procedure here
	@EMPID INT,
	@CURRENT_DATE DATE
AS
	
DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMPID),
		@DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMPID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	-- Insert statements for procedure here
	DECLARE @BILLABLES TABLE (PROJ_NAME VARCHAR(MAX), TOTAL_HOURS FLOAT)

	DECLARE @WeekNum INT, 
			@YearNum char(4)

	SELECT @WeekNum = DATEPART(WK, GETDATE()), 
		   @YearNum = CAST(DATEPART(YY, GETDATE()) AS CHAR(4));
    
	DECLARE @currentWeek DATE
	DECLARE @lastWeekStart DATE
	DECLARE @lastWeekEnd DATE

	-- Get the current week Monday
	SET @currentWeek = (SELECT DATEADD(wk, DATEDIFF(wk, 6, '1/1/' + @YearNum) + (@WeekNum-1), 7))
	-- Get the last week start range
	SET @lastWeekStart = (SELECT DATEADD(week, -1, @currentWeek))
	-- Get the last week end range
	SET @lastWeekEnd = (SELECT WEEK_END FROM WEEK_RANGE WHERE WEEK_START = @lastWeekStart)

	DECLARE @counter INT = 1
	DECLARE @totalProjects INT = (SELECT COUNT(*) FROM PROJECT WHERE DSPLY_FLG = 1)

	WHILE (@counter <= @totalProjects)
		BEGIN
			-- Get the project by row number
			DECLARE @projID INT = (SELECT PROJ_ID FROM ( 
										SELECT ROW_NUMBER() OVER (ORDER BY PROJ_ID) As RowNum, *
										FROM PROJECT WHERE DSPLY_FLG = 1) Data
								   WHERE RowNum = @counter)
			
			DECLARE @projName VARCHAR(MAX) = (SELECT PROJ_NAME FROM PROJECT WHERE PROJ_ID = @projID)

			IF EXISTS (SELECT * FROM PROJECT WHERE PROJ_ID = @projID AND DSPLY_FLG = 1)
				BEGIN
					DECLARE @totalHours FLOAT = (SELECT ISNULL(SUM(WR_ACT_EFFORT_WK), 0) 
										 FROM PROJECT P
										 LEFT JOIN WEEKLY_REPORT WR
											ON P.PROJ_ID = WR.WR_PROJ_ID
										 LEFT JOIN WEEK_RANGE W
											ON WR.WR_WEEK_RANGE_ID = W.WEEK_ID
										 LEFT JOIN EMPLOYEE E
											ON P.EMP_ID = E.EMP_ID
										 WHERE E.DEPT_ID = @DEPTID 
										    AND E.DIV_ID = @DIVID
											AND WR_WEEK_RANGE_ID = WEEK_ID AND
											  (WEEK_START BETWEEN @lastWeekStart AND @lastWeekEnd) AND
											   WR_PROJ_ID = @projID)

					INSERT INTO @BILLABLES VALUES (@projName, @totalHours)
				END
			SET @counter += 1
		END

	---- INSERT SL HOURS
	--INSERT INTO @BILLABLES
	--SELECT 'Sick Leave', ISNULL(SUM(COUNTS), 0) * 8  
	--FROM RESOURCE_PLANNER R
	--INNER JOIN STATUS S 
	--	ON R.STATUS = S.STATUS AND S.STATUS_ID IN (7, 9)
	--INNER JOIN EMPLOYEE E
	--	ON R.EMP_ID = E.EMP_ID
	--AND E.DEPT_ID = @DEPTID
	--AND E.DIV_ID = @DIVID
	--WHERE R.STATUS IN (3, 5)
	--AND DATE_ENTRY BETWEEN @lastWeekStart AND @lastWeekEnd

	---- Insert VL Hours
	--INSERT INTO @BILLABLES
	--SELECT 'Vacation Leave', ISNULL(SUM(COUNTS), 0) * 8  
	--FROM RESOURCE_PLANNER R 
	--INNER JOIN STATUS S 
	--	ON R.STATUS = S.STATUS AND S.STATUS_ID IN (7, 9) 
	--INNER JOIN EMPLOYEE E 
	--	ON R.EMP_ID = E.EMP_ID 
	--AND E.DEPT_ID = @DEPTID 
	--AND E.DIV_ID = @DIVID 
	--WHERE R.STATUS IN (4, 6, 8, 9)
	--AND DATE_ENTRY BETWEEN @lastWeekStart AND @lastWeekEnd
	
	---- Insert Holiday Hours
	--INSERT INTO @BILLABLES
	--SELECT 'Holiday', ISNULL(COUNT(EMP_ID), 0)
	--FROM ATTENDANCE  
	--WHERE STATUS IN (7)
	--AND DATE_ENTRY BETWEEN @lastWeekStart AND @lastWeekEnd

	SELECT PROJ_NAME AS EMPLOYEE_NAME, TOTAL_HOURS AS STATUS FROM @BILLABLES

END
GO
