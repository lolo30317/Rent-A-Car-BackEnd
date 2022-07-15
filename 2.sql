create table Users
(
Id int identity(1,1),
FirstName varchar(30),
LastName varchar(40),
Email varchar(30),
Password varchar(30),

);


create table Customers
(
Id int identity(1,1),
UserId int,
CompanyName varchar(50)

);

Alter table Customers add constraint fk_UserID_Referance foreign key(UserId) references Users(Id)


create table Rentals
(
Id int identity(1,1),
CarId int,
CustomerId int,
RentDate smallint,
ReturnDate smallint 

);

