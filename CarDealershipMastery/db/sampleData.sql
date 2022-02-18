use [GuildCars]
go

-- Make
set identity_insert [Make] on;
insert into [Make] ([MakeId], [Name], [DateAdded], [UserEmail])
values (0, 'Acura', '1/19/2022', 'test@example.com'),
(1, 'Buick', '1/19/2022', 'test@example.com'),
(2, 'Chrystler', '1/19/2022', 'test@example.com')
set identity_insert [Make] off;
go

-- Model
set identity_insert [Model] on;
insert into [Model] ([ModelId], [MakeId], [Name], [DateAdded], [UserEmail])
values (0, 0, 'Integra', '1/19/2022', 'test@example.com'),
(1, 1, 'Encore', '1/19/2022', 'test@example.com'),
(2, 2, '300C', '1/19/2022', 'test@example.com')
set identity_insert [Model] off;
go

-- BodyStyle
set identity_insert [BodyStyle] on;
insert into [BodyStyle] ([BodyStyleId], [Name])
values (0, 'Sedan'),
(1, 'Wagon'),
(2, 'SUV'),
(3, 'Truck'),
(4, 'Van')
set identity_insert [BodyStyle] off;
go

-- Transmission
set identity_insert [Transmission] on;
insert into [Transmission] ([TransmissionId], [Name])
values (0, 'Automatic'),
(1, 'Manual')
set identity_insert [Transmission] off;
go

-- Type
set identity_insert [Type] on;
insert into [Type] ([TypeId], [Name])
values (0, 'New'),
(1, 'Used')
set identity_insert [Type] off;
go

-- Color
set identity_insert [Color] on;
insert into [Color] ([ColorId], [Name])
values (0, 'Silver'),
(1, 'Gold'),
(2, 'Black'),
(3, 'Red'),
(4, 'Orange'),
(5, 'Yellow'),
(6, 'Green'),
(7, 'Blue'),
(8, 'White')
set identity_insert [Color] off;
go

-- Interior
set identity_insert [Interior] on;
insert into [Interior] ([InteriorId], [Name])
values (0, 'Black'),
(1, 'White'),
(2, 'Beige'),
(3, 'Gray')
set identity_insert [Interior] off;
go

-- State
insert into [State] ([StateId], [Name])
values ('MN', 'Minnesota'),
('OH', 'Ohio'),
('KY', 'Kentucky'),
('WI', 'Wisconsin'),
('IL', 'Illinois'),
('IN', 'Indiana')
go

-- PurchaseType
set identity_insert [PurchaseType] on;
insert into [PurchaseType] ([PurchaseTypeId], [Name])
values (0, 'Bank Finance'),
(1, 'Cash'),
(2, 'Dealer Finance')
set identity_insert [PurchaseType] off;
go

-- Car
set identity_insert [Car] on;
insert into [Car] ([CarId], [VIN], [ImgFileName], [Year], [Mileage], [Price], [MSRP], [Description], [IsSold], [IsFeatured], [ModelId], [InteriorId], [ColorId], [TypeId], [TransmissionId], [BodyStyleId])
values (0, 'AAA11111B22222222', 'inventory-0.png', 2020, 500, 20000, 22500, 'A simple car for your simpler life', 0, 1, 0, 0, 0, 0, 0, 0),
(1, 'BBB22222B33333333', 'inventory-1.png', 2010, 90000, 8500, 10000, 'A simpler car for your graduation present', 1, 0, 1, 1, 1, 1, 1, 1),
(2, 'CCC33333D44444444', 'inventory-2.png', 2020, 500, 14000, 20000, 'A simple car for your simpler life', 0, 0, 0, 0, 0, 0, 0, 0),
(3, 'DDD44444E55555555', 'inventory-3.png', 2010, 50000, 9500, 12500, 'A simpler car for your graduation present', 1, 1, 1, 1, 1, 1, 1, 1),
(4, 'AAAAAAAAAAAAAAAAA', 'inventory-4.png', 2010, 50000, 9500, 12500, 'A simpler car for your graduation present', 0, 1, 1, 1, 1, 1, 1, 1),
(5, 'BBBBBBBBBBBBBBBBB', 'inventory-5.png', 2010, 50000, 9500, 12500, 'A simpler car for your graduation present', 0, 1, 1, 1, 1, 1, 1, 1)
set identity_insert [Car] off;
go

-- Order
set identity_insert [Order] on;
insert into [Order] ([OrderId], [Name], [Email], [Phone], [StreetOne], [City], [Zipcode], [PurchasePrice], [UserEmail], [CarId], [PurchaseTypeId], [StateId], [DateAdded])
values (0, 'Jane Doe', 'janedoe@example.com', '5551234567', '123 Main Street', 'Minneapolis', '55401', 19500, 'test@example.com', 1, 0, 'MN', '1/19/2022'),
(1, 'John Smith', 'johnsmith@example.com', '5559876543', '321 Main Street', 'Minneapolis', '55401', 9500, 'test@example.com', 3, 0, 'MN', '1/19/2022')
set identity_insert [Order] off;
go

-- Special
set identity_insert [Special] on;
insert into [Special] ([SpecialId], [Title], [Description])
values (0, 'Example Special', 'Lorem ipsum dolor sit amet, et cetera')
set identity_insert [Special] off;
go

-- Contact
set identity_insert [Contact] on;
insert into [Contact] ([ContactId], [Name], [Email], [Phone], [Message])
values (0, 'Jane Doe', 'janedoe@example.com', '5551234567', 'I would like to negotiate the price for this Acura Integra')
set identity_insert [Contact] off;
go

-- Sample Users
-- Email: testAdmin@example.com
-- Pass: Password123!
-- Email: testSales@example.com
-- Pass: Password123!