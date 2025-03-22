


--food
--table
-- food catery
--account
--bill
--billinfo
create table Tablefood
(
	id int identity primary key, 
	name nvarchar(100) not null default N'Chưa đặt tên',
	status nvarchar(100) not null default N'Trống' -- trong -- co nguoi
);

go
create table FoodCategory(
	id int identity primary key not null, 
	name nvarchar(100) not null default N'Chưa đặt tên'
)
go
create table Food(
	id int identity primary key not null, 
	name nvarchar(100) not null default N'Chưa đặt tên',
	idCategory int not null foreign key (idCategory) references  FoodCategory(id),
	price float not null
)
go
create table Bill(
	id int identity primary key,
	DateCheckIn date not null default getdate(),
	gio time,
	idTable int not null,
	status int not null, -- 1 thanh toan 0 ko thanh toan
	foreign key (idTable) references Tablefood(id)
)
go
create table BillInfo(
	id int identity primary key,
	idBill int not null,
	idFood int not null,
	count int  not null default 0,
	foreign key (idBill) references Bill(id),
	foreign key (idFood) references Food(id)
)
drop table BillInfo
drop table Bill
drop table Food
drop table FoodCategory
drop table Tablefood


INSERT INTO Tablefood (name, status) VALUES (N'Bàn 3', N'Trống');
INSERT INTO Tablefood (name, status) VALUES (N'Bàn 4', N'Có người');


INSERT INTO FoodCategory (name) VALUES (N'Đồ ăn');
INSERT INTO FoodCategory (name) VALUES (N'Đồ uống');
INSERT INTO FoodCategory (name) VALUES (N'Đồ tráng miệng');


INSERT INTO Food (name, idCategory, price) VALUES (N'Phở bò', 1, 50000);
INSERT INTO Food (name, idCategory, price) VALUES (N'Bún chả', 1, 40000);
INSERT INTO Food (name, idCategory, price) VALUES (N'Cà phê sữa', 2, 25000);
INSERT INTO Food (name, idCategory, price) VALUES (N'Nước cam', 2, 30000);
INSERT INTO Food (name, idCategory, price) VALUES (N'Bánh flan', 3, 20000);


INSERT INTO Bill (DateCheckIn, gio, idTable, status) 
VALUES (GETDATE(), '12:30:00', 1, 1); 

INSERT INTO Bill (DateCheckIn, gio, idTable, status) 
VALUES (GETDATE(), '18:45:00', 1, 1);

INSERT INTO Bill (DateCheckIn, gio, idTable, status) 
VALUES (GETDATE(), '14:00:00', 2, 1);

INSERT INTO Bill (DateCheckIn, gio, idTable, status) 
VALUES (GETDATE(),'8:45:00', 2, 1);
delete from Bill where gio = '12:30:00';

select * from Bill
select  *from BillInfo

INSERT INTO BillInfo (idBill, idFood, count) VALUES (1, 1, 2); 
INSERT INTO BillInfo (idBill, idFood, count) VALUES (1, 2, 2); 
INSERT INTO BillInfo (idBill, idFood, count) VALUES (2, 2, 1);
INSERT INTO BillInfo (idBill, idFood, count) VALUES (2, 4, 2);
INSERT INTO BillInfo (idBill, idFood, count) VALUES (3, 2, 1);
INSERT INTO BillInfo (idBill, idFood, count) VALUES (3, 4, 2);








select * from Food
select * from Bill
select * from BillInfo
SELECT * FROM   Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id;
SELECT MAX(id) FROM Bill;