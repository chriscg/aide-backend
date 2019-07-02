USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetContactListAll]    Script Date: 07/01/2019 2:18:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetContactListAll]
	-- Add the parameters for the stored procedure here
	@EMAIL VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT b.EMP_ID,b.WS_EMP_ID, b.LAST_NAME, b.FIRST_NAME, b.MIDDLE_NAME, b.NICK_NAME, b.BIRTHDATE, c.DESCR AS 'POSITION', b.DATE_HIRED, d.DESCR AS 'MARITAL_STATUS', b.IMAGE_PATH,
		   e.DESCR AS 'PERMISSION_GROUP', f.DESCR AS 'DEPARTMENT', G.DESCR AS 'DIVISION', B.SHIFT_STATUS, A.EMAIL_ADDRESS, A.EMAIL_ADDRESS2, A.LOCATION, A.CEL_NO, A.LOCAL, A.HOMEPHONE, A.OTHER_PHONE, A.DT_REVIEWED
	FROM [dbo].[EMPLOYEE] b 
	INNER JOIN [dbo].[CONTACTS] a 
	ON a.emp_id = b.emp_id 
	INNER JOIN [dbo].[POSITION] c
	ON b.POS_ID = c.POS_ID
	INNER JOIN [dbo].[STATUS] d
	ON b.STATUS = d.STATUS
	INNER JOIN [dbo].[PERMISSION_GROUP] e
	ON b.GRP_ID = e.GRP_ID
	INNER JOIN [dbo].[DEPARTMENT] f
	ON b.DEPT_ID = f.DEPT_ID
	INNER JOIN [dbo].[DIVISION] G
	ON b.DIV_ID = G.DIV_ID
	WHERE d.STATUS_ID = 1
	AND b.DEPT_ID = (
		SELECT DEPT_ID FROM EMPLOYEE a
		INNER JOIN CONTACTS b 
		ON a.EMP_ID = b.EMP_ID
		WHERE b.EMAIL_ADDRESS = @EMAIL
		)
	AND b.DIV_ID = (
		SELECT DIV_ID FROM EMPLOYEE a
		INNER JOIN CONTACTS b 
		ON a.EMP_ID = b.EMP_ID
		WHERE b.EMAIL_ADDRESS = @EMAIL
		)
	ORDER BY b.LAST_NAME
END