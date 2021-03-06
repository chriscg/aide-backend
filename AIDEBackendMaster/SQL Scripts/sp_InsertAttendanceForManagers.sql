USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAttendanceForManagers]    Script Date: 06/30/2019 8:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_InsertAttendanceForManagers]
	@from datetime,
	@to datetime,
	@EMP_ID int ,
	@STATUS INT
AS
WHILE @from<=@to
BEGIN
	declare @COUNT tinyint = (select count(a.DATE_ENTRY) from ATTENDANCE a where a.EMP_ID = @EMP_ID and CONVERT(varchar,a.DATE_ENTRY,101) = Convert(date, @from))
	declare @FULL_NAME NVARCHAR(MAX) = (SELECT FIRST_NAME + ' ' + LAST_NAME FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

	if @COUNT = 0
		begin
			INSERT [dbo].[ATTENDANCE]
			(
				[EMP_ID],
				[DATE_ENTRY],
				[STATUS]
			)
			VALUES
			(
				@EMP_ID,
				@from,
				@STATUS	
			)
			exec [dbo].[sp_InsertResourcePlanner]
				 @EMP_ID = @EMP_ID ,
				 --@EMPLOYEE_NAME = @FULL_NAME,
				 @DATE_ENTRY = @from ,
				 @STATUS = @STATUS
		end 
	ELSE IF @COUNT > 0 AND @STATUS != 2
		BEGIN
			update ATTENDANCE set STATUS = @STATUS where EMP_ID = @EMP_ID and DATE_ENTRY = @from
			UPDATE RESOURCE_PLANNER SET STATUS = @STATUS, COUNTS = 1
			WHERE EMP_ID = @EMP_ID and DATE_ENTRY = @from
		END
	else
		begin
			update ATTENDANCE set STATUS = 2 where EMP_ID = @EMP_ID and DATE_ENTRY = Convert(datetime, getdate())
		end
	SET @from=DATEADD(DAY,1,@from)
END





