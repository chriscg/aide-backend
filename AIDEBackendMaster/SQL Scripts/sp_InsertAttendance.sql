USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAttendance]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertAttendance]
	@EMP_ID INT,
	@DATE_ENTRY DATETIME
AS

DECLARE @SHIFT VARCHAR(10) = (SELECT SHIFT_STATUS FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
declare @COUNT tinyint = (select count(a.DATE_ENTRY) from ATTENDANCE a where a.EMP_ID = @EMP_ID and CONVERT(varchar,a.DATE_ENTRY,101) = CONVERT(varchar, @DATE_ENTRY,101))
DECLARE @LOCATION NVARCHAR(MAX) = (SELECT LOCATION FROM CONTACTS WHERE EMP_ID = @EMP_ID)
DECLARE @STATUS INT = 2

IF @LOCATION != 'Eco Tower, BGC' AND @LOCATION != 'Net Square, BGC'
	BEGIN
		SET @STATUS = 1
	END

if @COUNT = 0
	begin
		IF CONVERT(VARCHAR(10), @DATE_ENTRY, 108) > '10:00:00' AND @SHIFT != 'Flexi'
		BEGIN
			SET @STATUS = 11
		END

		INSERT [dbo].[ATTENDANCE]
		(
			[EMP_ID],
			[DATE_ENTRY],
			[STATUS]

		)
		VALUES
		(
			@EMP_ID,
			@DATE_ENTRY,
			@STATUS
		)
	end
else
	begin
		declare @currStatus tinyint = (select STATUS from ATTENDANCE a where a.EMP_ID = @EMP_ID and CONVERT(varchar,a.DATE_ENTRY,101) = CONVERT(varchar, getdate(),101))
		if @currStatus <> 2
		begin
			update ATTENDANCE set STATUS = @STATUS, DATE_ENTRY = CONVERT(datetime, getdate()) where EMP_ID = @EMP_ID and CONVERT(varchar,DATE_ENTRY,101) = CONVERT(varchar, getdate(),101)
		end
	end






GO
