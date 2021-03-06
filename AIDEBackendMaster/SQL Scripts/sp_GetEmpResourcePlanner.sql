USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmpResourcePlanner]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetEmpResourcePlanner]
	-- Add the parameters for the stored procedure here
	@EMAIL_ADDRESS VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  A.EMP_ID, A.LAST_NAME + ', ' + A.FIRST_NAME + ' ' + SUBSTRING(A.MIDDLE_NAME,1,1) AS EMPLOYEE_NAME, A.IMAGE_PATH
	FROM EMPLOYEE A  
	WHERE a.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
				ON A.EMP_ID = B.EMP_ID
				WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
		  and a.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
				ON A.EMP_ID = B.EMP_ID
				WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
		  ORDER BY A.LAST_NAME ASC

END



GO
