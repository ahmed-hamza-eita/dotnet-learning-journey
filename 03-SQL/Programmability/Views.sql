--Create virtial tables for Reading

CREATE OR ALTER VIEW dbo.OrderDetails_vw
AS
Select 
    O.OrderID,
    O.CustomerID,
    O.OrderDate,
    OD.ProductID,
    OD.Quantity,
    OD.UnitPrice,
    (1 - OD.Discount) * OD.UnitPrice * OD.Quantity AS SubTotal
    From Orders As o
    Join 
    [Order Details] as od
    ON o.OrderID =od.OrderID

select * from dbo.OrderDetai    ls_vw