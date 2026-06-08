
	CREATE OR ALTER PROCEDURE dbo.SalesByCategoryAndYear_SP(
	@categoryName nvarchar(20), 
	@year int,
	@Count int output)
	AS
	BEGIN
		SELECT P.ProductName ,
		 ROUND(SUM(OD.Quantity * (1 - OD.Discount) * OD.UnitPrice), 2) As TotalPurchase 
		FROM
		[Order Details] as OD 
		INNER JOIN Orders as o ON od.OrderID=o.OrderID
		INNER JOIN Products as p ON od.ProductID =p.ProductID
		INNER JOIN Categories as c ON p.CategoryID = c.CategoryID
		WHERE C.CategoryName=@categoryName AND YEAR(O.OrderDate) =@year
		GROUP BY p.ProductName
		ORDER BY p.ProductName

		select @Count = @@ROWCOUNT
	END


select * from Categories

DECLARE @Count INT
EXEC dbo.SalesByCategoryAndYear_SP 'Dairy Products',1997, @Count OUTPUT
SELECT @Count AS [TOTAL DISTINCT PRODUCTS]

--GET Customer Order

select * from Customers
select * from Orders
select * from [Order Details]

CREATE OR ALTER PROCEDURE GetCustomerOrders_SP @CustomerId nvarchar(50) 
AS 
BEGIN
	SELECT
	o.OrderID,
	o.CustomerID,
	o.OrderDate,
	SUM((1-od.discount) * unitPrice * quantity) AS Total
	From [Order Details] AS od 
	join Orders AS o
	ON od.OrderID = o.OrderID
    WHERE O.CustomerID = @CustomerID
	Group By o.OrderID,o.CustomerID,o.OrderDate
END

EXEC dbo.GetCustomerOrders_SP 'ALFKI';


CREATE OR ALTER PROCEDURE dbo.CreateOrder_SP @CustomerId nvarchar(50)
AS
BEGIN 
	INSERT INTO Orders(CustomerID,OrderDate)
	VALUES (@CustomerId,GETDATE())
END

EXEC dbo.CreateOrder_SP 'ALFKI'

 
