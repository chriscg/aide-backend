USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllSabaCourses]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllSabaCourses]
@EMP_ID int

AS
DECLARE
		@DEPT_ID INT = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					   ON A.EMP_ID = B.EMP_ID WHERE B.EMP_ID = @EMP_ID),
		@DIV_ID INT = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					   ON A.EMP_ID = B.EMP_ID WHERE B.EMP_ID = @EMP_ID)
		
BEGIN							
	
	SELECT  a.SABA_ID as SABA_ID, a.EMP_ID AS EMP_ID, a.TITLE as TITLE, a.END_DATE AS END_DATE 
	from [dbo].[SABA_COURSES] a INNER JOIN EMPLOYEE B
	ON A.EMP_ID = B.EMP_ID
	WHERE B.DEPT_ID = @DEPT_ID AND B.DIV_ID = @DIV_ID


END
GO
