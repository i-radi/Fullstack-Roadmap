SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

Select * From tblMailingAddress
Select * From thlPhysicalAddress

Create Procedure spUpdateAddress
as
Begin
 Begin Try
  Begin Transaction

    Update thlMailingAddress set City = 'LONDON'
	where AddressId = 1 and EmployeeNumber = 101
	
	Update thlPhysicalAddress set City = 'LONDON'
	where AddressId = 1 and EmployeeNumber = 101

	Commit Transaction
	Print 'Transaction Comnitted'
 End Try

 Begin Catch
   Rollback Transaction
   Print 'Transaction Rollback'
 End Catch

End