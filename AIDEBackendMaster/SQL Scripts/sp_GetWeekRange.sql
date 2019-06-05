USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetWeekRange]    Script Date: 6/3/2019 12:46:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetWeekRange]
	@CURRENT_DATE DATE,
	@EMP_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @weekBefore DATE,
			@weekAfter DATE,
			@startWeek DATE,
			@tempDate DATE

	DECLARE @temptable TABLE (WEEKRANGEID INT, 
							  STARTWEEK DATE, 
							  ENDWEEK DATE,
							  DATERANGE VARCHAR(75))
	DECLARE @WeekNum INT, 
			@YearNum char(4)

	SELECT @WeekNum = DATEPART(WK, @CURRENT_DATE), 
		   @YearNum = CAST(DATEPART(YY, @CURRENT_DATE) AS CHAR(4));
						   
	-- Once you have the @WeekNum and @YearNum set, the following calculates the date range.
	SET @startWeek = (SELECT DATEADD(wk, DATEDIFF(wk, 6, '1/1/' + @YearNum) + (@WeekNum-1), 7))

	-- Get the Week Range
	SET @weekBefore = (SELECT DATEADD(week, -2, @startWeek))
	SET @weekAfter = (SELECT DATEADD(week, 2, @startWeek))

	INSERT INTO @temptable (WEEKRANGEID, STARTWEEK, ENDWEEK, DATERANGE)
	SELECT WEEK_ID, WEEK_START, WEEK_END, 
		   CONVERT(varchar, WEEK_START, 101) + ' - ' + 
		   CONVERT(varchar, WEEK_END, 101)
	FROM WEEK_RANGE 
	WHERE WEEK_ID NOT IN (SELECT DISTINCT WR_WEEK_RANGE_ID FROM WEEKLY_REPORT WHERE WR_EMP_ID = @EMP_ID) AND
	WEEK_START BETWEEN @weekBefore AND @weekAfter 
	
	SELECT * FROM @temptable
END


