USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAttendance]    Script Date: 07/04/2019 11:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_InsertAttendance]
	@EMP_ID INT,
	@DATE_ENTRY DATETIME
AS

DECLARE @SHIFT VARCHAR(10) = (SELECT SHIFT_STATUS FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
DECLARE @LOCATION NVARCHAR(MAX) = (SELECT LOCATION FROM CONTACTS WHERE EMP_ID = @EMP_ID)
DECLARE @STATUS INT = 2
DECLARE @COUNT TINYINT = (SELECT COUNT(a.DATE_ENTRY) FROM ATTENDANCE a 
						  WHERE a.EMP_ID = @EMP_ID 
						  AND CONVERT(VARCHAR,a.DATE_ENTRY,101) = CONVERT(VARCHAR, @DATE_ENTRY,101))

IF @LOCATION != 'Eco Tower, BGC'
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
	END
ELSE
	BEGIN
		DECLARE @currStatus INT = (SELECT STATUS FROM ATTENDANCE a 
									   WHERE a.EMP_ID = @EMP_ID 
									   AND CONVERT(VARCHAR,a.DATE_ENTRY,101) = CONVERT(VARCHAR, @DATE_ENTRY,101))
		IF NOT @currStatus IN (2,3,4,8,11)
		--<> 2 AND @currStatus <> 11 AND @currStatus <> 11 AND @currStatus <> 3 AND @currStatus <> 4 AND @currStatus <> 8
			BEGIN
				UPDATE ATTENDANCE SET STATUS = @STATUS 
				WHERE EMP_ID = @EMP_ID 
				AND CONVERT(VARCHAR,DATE_ENTRY,101) = CONVERT(VARCHAR, @DATE_ENTRY,101)
			END
	END





