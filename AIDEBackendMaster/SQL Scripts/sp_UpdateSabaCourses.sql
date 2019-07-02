USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSabaCourses]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateSabaCourses] 
@SABA_ID INT,
@EMP_ID INT, 
@TITLE VARCHAR(100), 
@END_DATE DATE
AS

BEGIN

UPDATE SABA_COURSES SET 
EMP_ID = @EMP_ID, 
TITLE =@TITLE, 
END_DATE = @END_DATE 
WHERE SABA_ID = @SABA_ID

END
GO
