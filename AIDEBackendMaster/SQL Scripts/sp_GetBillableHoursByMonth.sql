USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBillableHoursByMonth]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Author:		Batongbacal, Aevan Camille N. / J.H. Sanchez
-- Create date: Aug. 1, 2018
-- Description:	Get Billable hours per Dept and Div
-- ================================================
CREATE PROCEDURE [dbo].[sp_GetBillableHoursByMonth]
	-- Add the parameters for the stored procedure here
	@EMPID INT,
	@MONTH INT,
	@YEAR INT
AS
	
DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMPID),
		@DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMPID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	DECLARE @BILLABLES TABLE (PROJ_NAME VARCHAR(50), TOTAL_HOURS FLOAT)

	DECLARE @firstDayMonth DATE = (SELECT DATEADD(month, @MONTH-1, DATEADD(year, @YEAR-1900, 0)))
	DECLARE @endDayMonth DATE = (SELECT DATEADD(day, -1, DATEADD(month, @MONTH, DATEADD(year, @YEAR-1900, 0))))
	DECLARE @firstDateName VARCHAR(10) = (SELECT DATENAME(weekday, @firstDayMonth))
	DECLARE @endDateName VARCHAR(10) = (SELECT DATENAME(weekday, @endDayMonth))
	
	DECLARE @startDate DATE
	DECLARE @endDate DATE

	-- Set Begin Range
	IF @firstDateName != 'MONDAY'
		IF @firstDateName = 'SATURDAY' OR @firstDateName = 'SUNDAY'
			-- Set @startDate to first Monday of the Month
			SET @startDate = (SELECT DATEADD(wk, DATEDIFF(wk,0,DATEADD(dd,6-DATEPART(DAY, @firstDayMonth), @firstDayMonth)), 0))
		ELSE
			BEGIN
				DECLARE @WeekNum INT, 
						@YearNum char(4)

				SELECT @WeekNum = DATEPART(WK, @firstDayMonth), 
					   @YearNum = CAST(DATEPART(YY, @firstDayMonth) AS CHAR(4));
						   
				-- Set @startDate to the Monday of the current week
				SET @startDate = (SELECT DATEADD(wk, DATEDIFF(wk, 6, '1/1/' + @YearNum) + (@WeekNum-1), 7))
			END
	ELSE
		SET @startDate = @firstDayMonth
	
	-- Set End Range
	IF @endDateName != 'FRIDAY'
		SET @endDate = (SELECT DATEADD(DY,DATEDIFF(DY,'1900-01-05',DATEADD(MM,DATEDIFF(MM,'1900-01-01',@firstDayMonth),30))/7*7,'1900-01-05'))
	ELSE
		SET @endDate = @endDayMonth

	DECLARE @counter INT = 1
	DECLARE @totalProjects INT = (SELECT COUNT(*) FROM PROJECT WHERE DSPLY_FLG = 1)

	WHILE (@counter <= @totalProjects)
		BEGIN
			-- Get the project by row number
			DECLARE @projID INT = (SELECT PROJ_ID FROM ( 
										SELECT ROW_NUMBER() OVER (ORDER BY PROJ_ID) As RowNum, *
										FROM PROJECT) Data
								   WHERE RowNum = @counter)
			
			DECLARE @projName VARCHAR(50) = (SELECT PROJ_NAME FROM PROJECT WHERE PROJ_ID = @projID)

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
											  (WEEK_START BETWEEN @startDate AND @endDate) AND
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
	--AND DATE_ENTRY BETWEEN @startDate AND @endDate
	
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
	--AND DATE_ENTRY BETWEEN @startDate AND @endDate
	
	---- Insert Holiday Hours
	--INSERT INTO @BILLABLES
	--SELECT 'Holiday', ISNULL(COUNT(EMP_ID), 0)
	--FROM ATTENDANCE  
	--WHERE STATUS IN (7)
	--AND DATE_ENTRY BETWEEN @startDate AND @endDate


	SELECT PROJ_NAME AS EMPLOYEE_NAME, TOTAL_HOURS AS STATUS FROM @BILLABLES
END

GO
