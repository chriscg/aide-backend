USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNicknameByDeptID]    Script Date: 5/27/2019 2:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetNicknameByDeptID]
	-- Add the parameters for the stored procedure here
	@EMAIL VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT EMP_ID,NICK_NAME, CONCAT(LAST_NAME, ', ', FIRST_NAME) AS 'EMPLOYEE_NAME'
	FROM [dbo].[EMPLOYEE]
	WHERE DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
					 ON a.EMP_ID = b.EMP_ID
					 WHERE b.EMAIL_ADDRESS = @EMAIL)
		and DIV_ID = (SELECT DIV_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
					  ON a.EMP_ID = b.EMP_ID 
					  WHERE b.EMAIL_ADDRESS = @EMAIL)
	ORDER BY EMPLOYEE_NAME ASC
		
END
