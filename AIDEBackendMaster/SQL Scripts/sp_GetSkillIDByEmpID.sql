USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSkillIDByEmpID]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetSkillIDByEmpID]
	-- Add the parameters for the stored procedure here
	@EMP_ID int,
	@SKILL_ID INT	
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT count(prof_lvl) as 'PROF_LVL' FROM SKILLS_PROF A WHERE A.EMP_ID = @EMP_ID and a.SKILL_ID = @SKILL_ID
    -- Insert statements for procedure here

END


GO
