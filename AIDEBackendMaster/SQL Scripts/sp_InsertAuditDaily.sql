USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAuditDaily]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertAuditDaily]
	-- Add the parameters for the stored procedure here
	@AUDIT_QUESTIONS_ID INT,
	@EMP_ID INT,
	@FY_WEEK INT,
	@DT_CHECKED DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO WORKPLACE_AUDIT_DAILY
	VALUES (@AUDIT_QUESTIONS_ID, @EMP_ID, @FY_WEEK, @DT_CHECKED)

END

GO
