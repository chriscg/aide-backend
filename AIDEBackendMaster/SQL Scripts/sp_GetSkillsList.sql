USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSkillsList]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSkillsList]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.SKILL_ID, A.DESCR FROM SKILLS A inner join SKILLS_DEPT b on a.SKILL_ID = b.SKILL_ID
	where b.DISPLAY_FG = 1
	ORDER BY A.DSPLY_ORDR ASC, A.DESCR ASC
END



GO
