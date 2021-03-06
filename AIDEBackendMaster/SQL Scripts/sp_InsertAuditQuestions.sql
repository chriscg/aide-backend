USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAuditQuestions]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertAuditQuestions]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@AUDIT_QUESTIONS VARCHAR(MAX),
	@OWNER VARCHAR(50),
	@AUDIT_QUESTIONS_GROUP VARCHAR(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO WORKPLACE_AUDIT_QUESTIONS
	VALUES (@EMP_ID, @AUDIT_QUESTIONS, @OWNER, @AUDIT_QUESTIONS_GROUP)
END

GO
