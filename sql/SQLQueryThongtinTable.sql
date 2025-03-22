



-- them  de thuc hien Bill 




-- thêm vào FoodCetagory . 
INSERT INTO FoodCategory(name) 
VALUES (N'Hải sản');

INSERT INTO FoodCategory(name) 
VALUES (N'Nông sản');

INSERT INTO FoodCategory(name) 
VALUES (N'Nước');

INSERT INTO FoodCategory(name) 
VALUES (N'Ăn vặt');

INSERT INTO FoodCategory(name) 
VALUES (N'Món tráng miệng');


-- them vào table Food . 
INSERT INTO Food (name, idCategory, price)
VALUES (N'tôm', 1, 150);

INSERT INTO Food (name, idCategory, price)
VALUES (N'cá hồi', 1, 200);

INSERT INTO Food (name, idCategory, price)
VALUES (N'ngô chiên', 2, 100);

INSERT INTO Food (name, idCategory, price)
VALUES (N'khoai tây chiên', 2, 120);

INSERT INTO Food (name, idCategory, price)
VALUES (N'nước dừa', 3, 30);

INSERT INTO Food (name, idCategory, price)
VALUES (N'nước cam', 3, 25);

INSERT INTO Food (name, idCategory, price)
VALUES (N'bánh tráng nướng', 4, 50);

INSERT INTO Food (name, idCategory, price)
VALUES (N'bánh bột lọc', 4, 60);

INSERT INTO Food (name, idCategory, price)
VALUES (N'chè đậu xanh', 5, 40);

INSERT INTO Food (name, idCategory, price)
VALUES (N'chè ba màu', 5, 45);


select * from Food , FoodCategory 
where 2 =  Food.idCategory

insert into Bill( DateCheckIn , DateCheckout , idTable , status )
values(GETDATE() , null , 2 , N'chưa thanh toán ')



select * from Tablefood
INSERT INTO Tablefood (name, status)
VALUES
  (N'bàn 1', N'Trống'),
  (N'bàn 2', N'Đã đặt'),
  (N'bàn 3', N'Trống'),
  (N'bàn 4', N'Đã đặt'),
  (N'bàn 5', N'Trống');


select *from Bill 
INSERT INTO Bill (DateCheckIn, DateCheckout, idTable, status)
VALUES [dbo].[Bill]
  (GETDATE(), NULL, 2,1),
  (GETDATE(), NULL, 3,0),
  (GETDATE(), NULL, 4,0),
  (GETDATE(), NULL, 5,1),
  (GETDATE(), NULL, 6,0);


//  chen du lieu vao bang .
INSERT INTO BillInfo (idBill, idFood, count)
VALUES 
  (4, 2, 3),  -- Hóa đơn 1, Món ăn 2, Số lượng 3
  (6, 3, 2),  -- Hóa đơn 1, Món ăn 3, Số lượng 2
  (2, 1, 1),  -- Hóa đơn 2, Món ăn 1, Số lượng 1
  (5, 4, 5),  -- Hóa đơn 2, Món ăn 4, Số lượng 5
  (3, 2, 2);  -- Hóa đơn 3, Món ăn 2, Số lượng 2


  select * from BillInfo where idBill = 15  and idFood = 6

  select * from Food 
  select *from Bill 
  select *from BillInfo