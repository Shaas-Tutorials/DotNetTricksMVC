create procedure usp_getProduct
@ProductId int
As
Begin
	Select * from [dbo].[Product] where ProductId=@ProductId
End

GO

create function fn_getProduct(
@ProductId int)
returns Table
As
return (Select * from [dbo].[Product] where ProductId=@ProductId)
