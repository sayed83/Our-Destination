ALTER PROCEDURE [dbo].[rptMonthlyPayment]

AS
	SELECT m.MemberNo,m.MemberName,pt.PaymentType,d.DepartmentName FROM PaymentAmounts p
	inner join Members m on m.MemberId = p.MemberId
	inner join MemberPaymentTypes pt on pt.PaymentId = p.PaymentTypeId
	inner join Departments d on d.DepartmentId = p.DepartmentId
RETURN 0

EXEC [rptMonthlyPayment] 

SELECT * FROM MonthlyPaymentSetups
SELECT * FROM MemberPaymentTypes