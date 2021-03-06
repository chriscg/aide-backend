USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertNewSuccessRegister]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_InsertNewSuccessRegister](
@Emp_Id int,
@date_input date ,
@Detailsofsuccess text ,
@WhosInvolve text,
@AdditionalInformation text)
as
begin
	set nocount on
	insert into [dbo].[SUCCESSREGISTER]
	(
	[EMP_ID],
	[DATE_INPUT],
	[DETAILSOFSUCCESS],
	[WHOSINVOLVE],
	[ADDITIONALINFORMATION]
	)
	values(
	@Emp_Id,
	@date_input,
	@Detailsofsuccess,
	@WhosInvolve,
	@AdditionalInformation)
	END

GO
