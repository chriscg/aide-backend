USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAuditQuestions]    Script Date: 10/11/2019 6:23:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetAuditQuestions]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@QUESTION_GROUP VARCHAR(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

    -- Insert statements for procedure here
	SELECT A.* FROM WORKPLACE_AUDIT_QUESTIONS A INNER JOIN EMPLOYEE B
	ON A.EMP_ID = B.EMP_ID
	WHERE A.AUDIT_QUESTIONS_GROUP = @QUESTION_GROUP AND B.DEPT_ID = @DEPTID
END
