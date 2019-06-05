USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSkillsProfByEmpId]    Script Date: 5/27/2019 11:33:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_UpdateSkillsProfByEmpId]
	@EMP_ID int,
	@SKILL_ID int,
	@PROF_LVL int,
	@LAST_REVIEWED DATETIME

AS

UPDATE [dbo].[SKILLS_PROF]
SET 
	[PROF_LVL] = @PROF_LVL
WHERE 
	[EMP_ID] = @EMP_ID AND 
	[SKILL_ID] = @SKILL_ID

UPDATE [dbo].[SKILLS_PROF]
SET
	[LAST_REVIEWED] = @LAST_REVIEWED
WHERE 
	[EMP_ID] = @EMP_ID 