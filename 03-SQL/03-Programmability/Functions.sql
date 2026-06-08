select * from Customers;
select * from Products;
select * from Categories;
select * from Orders;
select * from [Order Details];

--Before Function
Select
OD.OrderID,
OD.ProductID,
OD.UnitPrice,
OD.Quantity,
CONVERT(money, (1-od.Discount)* od.UnitPrice * od.Quantity,2) as SubTotal
from [Order Details] as OD 
WHERE od.OrderID =10250


Select
o.OrderID , o.CustomerID , o.OrderDate,
Convert(money,sum((1-od.Discount) * od.Quantity * od.UnitPrice),2) as Total
from
orders o inner join [order details]  od	
on o.orderId = od.orderId
where o.OrderID=10250
group by o.OrderID , o.CustomerID , o.OrderDate

--Since the subtotal calculation is used multiple times, we'll encapsulate it in a function.


--After Function
Select
OD.OrderID,
OD.ProductID,
OD.UnitPrice,
OD.Quantity,
dbo.CalculateSubTotal(OD.Quantity,OD.UnitPrice,OD.Discount) as SubTotal --used function
from [Order Details] as OD 
WHERE od.OrderID =10250

Select
o.OrderID , o.CustomerID , o.OrderDate,
sum(dbo.CalculateSubTotal(OD.Quantity,OD.UnitPrice,OD.Discount)) as Total
from
orders o inner join [order details]  od	
on o.orderId = od.orderId
where o.OrderID=10250
group by o.OrderID , o.CustomerID , o.OrderDate


-- 1- Scaler Function -> return single value
CREATE OR ALTER FUNCTION dbo.CalculateSubTotal
(
    @quantity INT,
    @unitPrice MONEY,
    @discount REAL
)
RETURNS MONEY
WITH SCHEMABINDING
AS
BEGIN
    DECLARE @SubTotal MONEY;

    SET @SubTotal = ROUND((1 - @discount) * @quantity * @unitPrice, 2);

    RETURN @SubTotal;
END

CREATE OR ALTER FUNCTION dbo.CalculateOrderTotal(@orderId INT)
RETURNS MONEY
AS
BEGIN
    DECLARE @total MONEY;

    SELECT @total = SUM(SubTotal)
    FROM dbo.GetOrderDetails(@orderId);

    RETURN ISNULL(@total, 0);
END



CREATE OR ALTER FUNCTION dbo.GetProductPriceAfterDiscount
(
    @ProductID INT
)
RETURNS MONEY
AS
BEGIN
    DECLARE @price MONEY;

    SELECT @price = UnitPrice * (1 - ISNULL(Discontinued,0))
    FROM Products
    WHERE ProductID = @ProductID;

    RETURN @price;
END

SELECT ProductName,
       dbo.GetProductPriceAfterDiscount(ProductID) AS FinalPrice
FROM Products;

 
-- 2-Table Value Function
CREATE OR ALTER FUNCTION dbo.GetOrderDetails(@orderId INT)
RETURNS TABLE
AS
RETURN
(
    SELECT
        OD.OrderID,
        OD.ProductID,
        OD.UnitPrice,
        OD.Quantity,
        ROUND((1 - OD.Discount) * OD.UnitPrice * OD.Quantity, 2) AS SubTotal
    FROM [Order Details] OD
    WHERE OD.OrderID = @orderId
);

select * from dbo.GetOrderDetails(10250)


CREATE OR ALTER FUNCTION dbo.GetCustomerOrders (@customerID NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT 
        O.OrderID,
        O.CustomerID,
        O.OrderDate,
        ROUND(SUM((1 - OD.Discount) * OD.UnitPrice * OD.Quantity),2) AS Total
    FROM Orders O
    JOIN [Order Details] OD
    ON O.OrderID = OD.OrderID
    WHERE O.CustomerID = @customerID
    GROUP BY O.OrderID, O.CustomerID, O.OrderDate
);


SELECT * FROM GetCustomerOrders('ALFKI')
SELECT * FROM Orders
where CustomerID ='ALFKI'


-- 3- System Functions

-- Numeric Function 
SELECT ABS(-100);

-- DATE FUNCITON
SELECT GETDATE();
SELECT ISDATE('2000-10-20'); 

-- String Function
SELECT LEN('this is some text')
SELECT UPPER('issam');

-- CONVERSION Function
SELECT ROUND('100.021', 2);