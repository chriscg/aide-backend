USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSkillsProfByEmpID]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSkillsProfByEmpID]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.EMP_ID, A.LAST_NAME + ' ' + A.FIRST_NAME + ' ' + SUBSTRING(A.MIDDLE_NAME, 1, 1) AS EMPLOYEE_NAME,
		   C.DESCR, B.PROF_LVL, B.LAST_REVIEWED
	FROM EMPLOYEE A inner join SKILLS_PROF B ON A.EMP_ID = B.EMP_ID
	INNER JOIN SKILLS C ON C.SKILL_ID = B.SKILL_ID 
	INNER JOIN SKILLS_DEPT D ON C.SKILL_ID = D.SKILL_ID 
	WHERE A.EMP_ID = @EMP_ID AND D.DISPLAY_FG = 1 ORDER BY C.DSPLY_ORDR ASC, C.DESCR ASC
END
GO
