--Level 1: The Join Foundation

select c.CategoryName,p.ProductName
from products p join Categories c
on p.CategoryID = c.CategoryID
group by c.CategoryName, p.ProductName;


WITH OrderProductCount AS (           --cte
    SELECT OrderID, COUNT(*) AS ProductCount
    FROM [Order Details]
    GROUP BY OrderID
)

SELECT c.CustomerID,
       c.CompanyName,
       COUNT(DISTINCT o.OrderID) AS TotalOrders
FROM Customers c
JOIN Orders o
    ON c.CustomerID = o.CustomerID
JOIN OrderProductCount opc
    ON o.OrderID = opc.OrderID
GROUP BY c.CustomerID, c.CompanyName
HAVING COUNT(DISTINCT o.OrderID) >= 2      
   AND MIN(opc.ProductCount) >= 1          
   AND MAX(opc.ProductCount) > 1;          

select o.orderid, c.companyname, c.contactname
from orders o join customers c on o.Customerid= c.customerid;

select p.productname, s.companyname
from products p
inner join suppliers s
    on p.supplierid = s.supplierid;

select o.orderid, o.orderdate, e.firstname, e.lastname
from orders o
inner join employees e
    on o.employeeid = e.employeeid;

select o.orderid, s.companyname as shippername
from orders o
inner join shippers s
    on o.shipvia = s.shipperid
where o.shipcountry = 'france';

--Level 2: Aggregations with Joins

select c.categoryname,
       sum(p.unitsinstock) as totalunitsinstock
from categories c
inner join products p
    on c.categoryid = p.categoryid
group by c.categoryname;


select c.companyname,
       sum(od.unitprice * od.quantity) as totalspent
from customers c
inner join orders o
    on c.customerid = o.customerid
inner join [order details] od
    on o.orderid = od.orderid
group by c.companyname;


select e.lastname,
       count(o.orderid) as totalorders
from employees e
left join orders o
    on e.employeeid = o.employeeid
group by e.lastname;


select s.companyname,
       sum(o.freight) as totalfreight
from shippers s
inner join orders o
    on s.shipperid = o.shipvia
group by s.companyname;


select top 5 p.productname,
       sum(od.quantity) as totalsold
from products p
inner join [order details] od
    on p.productid = od.productid
group by p.productname
order by totalsold desc;

--Level 3: subqueries & self-joins

select productname
from products
where unitprice > (
    select avg(unitprice) from products
);

select 
    e.firstname + ' ' + e.lastname as employeename,
    m.firstname + ' ' + m.lastname as managername
from employees e
left join employees m
    on e.reportsto = m.employeeid;


select companyname
from customers c
where not exists (
    select 1
    from orders o
    where o.customerid = c.customerid
);


select o.orderid
from orders o
inner join [order details] od
    on o.orderid = od.orderid
group by o.orderid
having sum(od.unitprice * od.quantity) >
(
    select avg(ordertotal)
    from (
        select sum(unitprice * quantity) as ordertotal
        from [order details]
        group by orderid
    ) t
);

select p.productname
from products p
where not exists (
    select 1
    from [order details] od
    inner join orders o
        on od.orderid = o.orderid
    where od.productid = p.productid
      and year(o.orderdate) > 1997
);

--Level 4: complex logic & advanced joins

select e.firstname, e.lastname, r.regiondescription
from employees e
inner join employeeterritories et
    on e.employeeid = et.employeeid
inner join territories t
    on et.territoryid = t.territoryid
inner join region r
    on t.regionid = r.regionid;


select c.companyname as customername,
       s.companyname as suppliername,
       c.city
from customers c
inner join suppliers s
    on c.city = s.city;


select c.companyname
from customers c
inner join orders o
    on c.customerid = o.customerid
inner join [order details] od
    on o.orderid = od.orderid
inner join products p
    on od.productid = p.productid
group by c.companyname
having count(distinct p.categoryid) > 3;


select sum(od.unitprice * od.quantity) as discontinuedrevenue
from [order details] od
inner join products p
    on od.productid = p.productid
where p.discontinued = 1;


select c.categoryname,
       p.productname,
       p.unitprice
from products p
inner join categories c
    on p.categoryid = c.categoryid
where p.unitprice =
(
    select max(p2.unitprice)
    from products p2
    where p2.categoryid = p.categoryid
);




   


