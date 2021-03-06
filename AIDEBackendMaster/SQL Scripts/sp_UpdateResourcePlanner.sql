USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateResourcePlanner]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateResourcePlanner]
	@from datetime,
	@to datetime,
	@EMP_ID int ,
	@STATUS INT

AS

WHILE @from<=@to
	BEGIN
        declare @COUNT_RP tinyint = (select count(a.DATE_ENTRY) from RESOURCE_PLANNER a where a.EMP_ID = @EMP_ID AND a.DATE_ENTRY = CONVERT(date, @from)),
				@COUNT_A tinyint = (select count(a.DATE_ENTRY) from ATTENDANCE a where a.EMP_ID = @EMP_ID and CONVERT(varchar,a.DATE_ENTRY,101) = Convert(varchar, @from,101)),
				@FULL_NAME NVARCHAR(MAX) = (SELECT FIRST_NAME + ' ' + LAST_NAME FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
		if @COUNT_RP >= 1 OR @COUNT_A = 1
			begin
				update ATTENDANCE set STATUS = @STATUS where EMP_ID = @EMP_ID and CONVERT(DATE,DATE_ENTRY) = CONVERT(DATE,@from)
				if @COUNT_RP = 0
					begin
						exec [dbo].[sp_InsertResourcePlanner]
							@EMP_ID = @EMP_ID ,
							--@EMPLOYEE_NAME = @FULL_NAME,
							@DATE_ENTRY = @from ,
							@STATUS = @STATUS
					end
				else
					begin
						UPDATE RESOURCE_PLANNER SET
								STATUS = @STATUS
						WHERE EMP_ID = @EMP_ID AND
								DATE_ENTRY = @from
					end
			end 
		else
			if @STATUS = 7 --HOLIDAY
			begin
				INSERT INTO [dbo].[ATTENDANCE]
				SELECT E.EMP_ID, @from,
						@STATUS FROM dbo.EMPLOYEE E INNER JOIN CONTACTS C
						ON E.EMP_ID = C.EMP_ID
				WHERE C.LOCATION = 'Eco Tower, BGC' OR C.LOCATION = 'Net Square, BGC'
					  AND E.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
						ON A.EMP_ID = B.EMP_ID WHERE A.EMP_ID = @EMP_ID) AND
					  E.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
						ON A.EMP_ID = B.EMP_ID WHERE A.EMP_ID = @EMP_ID)
			end
			else
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
					BEGIN
						exec [dbo].[sp_InsertResourcePlanner]
							@EMP_ID = @EMP_ID ,
							--@EMPLOYEE_NAME = @FULL_NAME,
							@DATE_ENTRY = @from ,
							@STATUS = @STATUS
					END
				end

		 SET @from = (SELECT dbo.DAYSADDNOWK(@from, 1))
	END
GO
