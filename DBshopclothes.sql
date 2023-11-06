create database shopclothes;
go 
use shopclothes;
go
CREATE TABLE Payment
(
  Patment_ID INT NOT NULL,
  Payment_Name nvarchar(50) NOT NULL,
  PRIMARY KEY (Patment_ID)
);
go
CREATE TABLE Category
(
  Catogory_ID INT NOT NULL,
  Name_Cate nvarchar(50) NOT NULL,
  PRIMARY KEY (Catogory_ID)
);
go
CREATE TABLE Role
(
  Role_ID INT NOT NULL,
  Role_Name nvarchar(50) NOT NULL,
  Description nvarchar(max) NOT NULL,
  PRIMARY KEY (Role_ID)
);
go
CREATE TABLE Employee
(
  Emp_ID INT NOT NULL,
  Emp_Name nvarchar(50) NOT NULL,
  Address nvarchar(100) NOT NULL,
  Phone INT NOT NULL,
  Gender INT NOT NULL,
  Account nvarchar(50) NOT NULL,
  Password nvarchar(50) NOT NULL,
  Birthday date NOT NULL,
  PRIMARY KEY (Emp_ID)
);
go
CREATE TABLE Supplier
(
  Sup_ID INT NOT NULL,
  Sup_Name nvarchar(50) NOT NULL,
  Address nvarchar(100) NOT NULL,
  PRIMARY KEY (Sup_ID)
);
go
CREATE TABLE Post
(
  Post_ID INT NOT NULL,
  Created_at date NOT NULL,
  Description nvarchar(max) NOT NULL,
  Title nvarchar(max) NOT NULL,
  Status nvarchar(50) NOT NULL,
  modified_at date NOT NULL,
  Emp_ID INT NOT NULL,
  PRIMARY KEY (Post_ID),
  FOREIGN KEY (Emp_ID) REFERENCES Employee(Emp_ID)
);
go
CREATE TABLE Customer
(
  Cus_ID INT NOT NULL,
  Cus_Name nvarchar(50) NOT NULL,
  Address nvarchar(max) NOT NULL,
  Phone INT NOT NULL,
  Account nvarchar(50) NOT NULL,
  Password nvarchar(50) NOT NULL,
  Create_Date date NOT NULL,
  Status nvarchar(50) NOT NULL,
  gender INT NOT NULL,
  PRIMARY KEY (Cus_ID)
);
go
CREATE TABLE Product
(
  Product_ID INT NOT NULL,
  Name_Product nvarchar(50) NOT NULL,
  Description nvarchar(max) NOT NULL,
  Price INT NOT NULL,
  Quantity_inventory INT NOT NULL,
  Catogory_ID INT NOT NULL,
  PRIMARY KEY (Product_ID),
  FOREIGN KEY (Catogory_ID) REFERENCES Catogory(Catogory_ID)
);
go
CREATE TABLE User
(
  User_ID INT NOT NULL,
  User_Name nvarchar(50) NOT NULL,
  Address nvarchar(max) NOT NULL,
  Gender INT NOT NULL,
  Phone INT NOT NULL,
  Account nvarchar(50) NOT NULL,
  Password nvarchar(50) NOT NULL,
  Create_Date date NOT NULL,
  Role_ID INT NOT NULL,
  PRIMARY KEY (User_ID),
  FOREIGN KEY (Role_ID) REFERENCES Role(Role_ID)
);
go
CREATE TABLE Order
(
  Order_ID INT NOT NULL,
  Order_Date date NOT NULL,
  ShoppingAddress nvarchar(max) NOT NULL,
  total_Price INT NOT NULL,
  Payment_menthod nvarchar(50) NOT NULL,
  Note nvarchar(max) NOT NULL,
  Discount nvarchar(50) NOT NULL,
  Status nvarchar(max) NOT NULL,
  Emp_ID INT NOT NULL,
  Cus_ID INT NOT NULL,
  PRIMARY KEY (Order_ID),
  FOREIGN KEY (Emp_ID) REFERENCES Employee(Emp_ID),
  FOREIGN KEY (Cus_ID) REFERENCES Customer(Cus_ID)
);
go
CREATE TABLE Order_detail
(
  Order_Detail_ID INT NOT NULL,
  Quantity INT NOT NULL,
  Price INT NOT NULL,
  Order_ID INT NOT NULL,
  Product_ID INT NOT NULL,
  PRIMARY KEY (Order_Detail_ID),
  FOREIGN KEY (Order_ID) REFERENCES Order(Order_ID),
  FOREIGN KEY (Product_ID) REFERENCES Product(Product_ID)
);
go
CREATE TABLE Cart
(
  Cart_ID INT NOT NULL,
  Quantity INT NOT NULL,
  Created_at date NOT NULL,
  Price INT NOT NULL,
  Total nvarchar(max) NOT NULL,
  Product_ID INT NOT NULL,
  PRIMARY KEY (Cart_ID),
  FOREIGN KEY (Product_ID) REFERENCES Product(Product_ID)
);