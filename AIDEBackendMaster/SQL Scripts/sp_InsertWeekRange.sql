USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertWeekRange]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertWeekRange]
	@CURRENT_DATE DATE
AS
BEGIN
	DECLARE @lastEntry DATE,
			@startOfWeek DATE,
			@endOfWeek DATE,
			@startDate DATE,
			@tempDate DATE 

	DECLARE @WeekNum INT, 
			@YearNum char(4)

	DECLARE @numberOfWeeks INT 
	DECLARE @counter INT = 1

	SET @lastEntry = (SELECT TOP 1 WEEK_START FROM WEEK_RANGE ORDER BY WEEK_START DESC )

	SELECT @WeekNum = DATEPART(WK, @CURRENT_DATE), 
	       @YearNum = CAST(DATEPART(YY, @CURRENT_DATE) AS CHAR(4));
	
	-- Once you have the @WeekNum and @YearNum set, the following calculates the date range.
	SET @startOfWeek = (SELECT DATEADD(wk, DATEDIFF(wk, 6, '1/1/' + @YearNum) + (@WeekNum-1), 7))
	SET @endOfWeek = (SELECT DATEADD(wk, DATEDIFF(wk, 5, '1/1/' + @YearNum) + (@WeekNum-1), 6))

	IF @lastEntry IS NULL
		BEGIN
			SET @numberOfWeeks = 5
			SET @startDate = (SELECT DATEADD(week, -2, @startOfWeek))
		END
	ELSE
		BEGIN
			SET @tempDate = (SELECT DATEADD(week, 2, @startOfWeek))
			IF @lastEntry = @tempDate OR @startOfWeek = @lastEntry
				SET @numberOfWeeks = 2
				SET @startDate = (SELECT DATEADD(week, 1, @lastEntry))
		END

	WHILE (@counter <= @numberOfWeeks)
	BEGIN
		SELECT @WeekNum = DATEPART(WK, @startDate), 
			   @YearNum = CAST(DATEPART(YY, @startDate) AS CHAR(4));
	
		-- Once you have the @WeekNum and @YearNum set, the following calculates the date range.
		SET @startOfWeek = (SELECT DATEADD(wk, DATEDIFF(wk, 6, '1/1/' + @YearNum) + (@WeekNum-1), 7))
		SET @endOfWeek = (SELECT DATEADD(wk, DATEDIFF(wk, 5, '1/1/' + @YearNum) + (@WeekNum-1), 6))
		
		-- Insert Week Data
		INSERT INTO WEEK_RANGE (WEEK_START, WEEK_END) 
		VALUES (@startOfWeek, @endOfWeek)

		-- SET startDate to next week
		SET @startDate = (SELECT DATEADD(week, 1, @startDate))
		SET @counter += 1
	END
END
GO
