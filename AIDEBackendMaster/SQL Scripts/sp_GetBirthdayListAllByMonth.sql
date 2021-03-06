USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBirthdayListAllByMonth]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Batongbacal, Aevan Camille N.
-- Create date: August 23, 2017
-- Description:	Used to get the list of Contact 
--				information of the department
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetBirthdayListAllByMonth]
	-- Add the parameters for the stored procedure here
	@EMAIL VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT b.FIRST_NAME,b.LAST_NAME,b.BIRTHDATE, b.EMP_ID, b.IMAGE_PATH
	FROM [dbo].[EMPLOYEE] b 
	INNER JOIN [dbo].[CONTACTS] a 
	ON a.emp_id = b.emp_id 
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
		AND
		MONTH(b.BIRTHDATE) = MONTH(GETDATE())
		ORDER BY DAY(b.BIRTHDATE)
END

GO
