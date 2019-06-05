USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAllSkillsByEmpID]    Script Date: 5/27/2019 2:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateAllSkillsByEmpID]
	@EMP_ID int,
	@LAST_REVIEWED DATETIME

AS

UPDATE [dbo].[SKILLS_PROF]
SET
	[LAST_REVIEWED] = @LAST_REVIEWED
WHERE 
	[EMP_ID] = @EMP_ID 