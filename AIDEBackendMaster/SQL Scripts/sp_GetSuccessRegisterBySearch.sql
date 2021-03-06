USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSuccessRegisterBySearch]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetSuccessRegisterBySearch]
	-- Add the parameters for the stored procedure here
	@INPUT VARCHAR,
	@EMAIL VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.ID,a.EMP_ID,a.DATE_INPUT,a.DETAILSOFSUCCESS,a.ADDITIONALINFORMATION,a.WHOSINVOLVE,b.NICK_NAME,b.DEPT_ID 
	FROM [dbo].[SUCCESSREGISTER] a INNER JOIN [dbo].[EMPLOYEE] b 
	on a.emp_id = b.emp_id 
	WHERE (b.DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
						ON a.EMP_ID = b.EMP_ID
						WHERE b.EMAIL_ADDRESS = @EMAIL)
		AND B.DIV_ID = (SELECT DIV_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
						ON a.EMP_ID = b.EMP_ID
						WHERE b.EMAIL_ADDRESS = @EMAIL))
		AND ((a.[DETAILSOFSUCCESS] LIKE '%' + @INPUT + '%' ) OR
		  (a.[WHOSINVOLVE] LIKE '%' + @INPUT + '%') OR
		  (a.[ID] LIKE '%' + @INPUT + '%') OR
		  (a.[ADDITIONALINFORMATION] LIKE '%' + @INPUT + '%') OR
		  (b.[NICK_NAME] LIKE '%' + @INPUT + '%'))
	ORDER BY A.DATE_INPUT DESC
	
END

GO
