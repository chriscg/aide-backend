USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetContactListAll]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetContactListAll]
	-- Add the parameters for the stored procedure here
	@EMAIL VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT *
	FROM [dbo].[EMPLOYEE] b 
	INNER JOIN [dbo].[CONTACTS] a 
	ON a.emp_id = b.emp_id 
	INNER JOIN [dbo].[POSITION] c
	ON b.POS_ID = c.POS_ID
	WHERE b.DEPT_ID =  (
		SELECT DEPT_ID FROM EMPLOYEE a
		INNER JOIN CONTACTS b 
		ON a.EMP_ID = b.EMP_ID
		WHERE b.EMAIL_ADDRESS = @EMAIL
		)
	AND b.DIV_ID =  (
		SELECT DIV_ID FROM EMPLOYEE a
		INNER JOIN CONTACTS b 
		ON a.EMP_ID = b.EMP_ID
		WHERE b.EMAIL_ADDRESS = @EMAIL
		)
	ORDER BY b.LAST_NAME
END

GO
