use [GuildCarsTest]
go


if exists(select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'DbReset')
	drop procedure DbReset
go

create procedure DbReset as
begin
	truncate table [Order];
	truncate table [Car];
	truncate table [PurchaseType];
	truncate table [State];
	truncate table [Interior];
	truncate table [Color];
	truncate table [Type];
	truncate table [Transmission];
	truncate table [BodyStyle];
	truncate table [Model];
	truncate table [Make];
	truncate table [Special];
	truncate table [Contact];
	truncate table [AspNetUserRoles];
	truncate table [AspNetUsers];
	truncate table [AspNetRoles];

	-- Make
set identity_insert [Make] on;
insert into [Make] ([MakeId], [Name], [DateAdded], [UserEmail])
values (0, 'Acura', '1/19/2022', 'test@example.com'),
(1, 'Buick', '1/19/2022', 'test@example.com'),
(2, 'Chrystler', '1/19/2022', 'test@example.com')
set identity_insert [Make] off;

-- Model
set identity_insert [Model] on;
insert into [Model] ([ModelId], [MakeId], [Name], [DateAdded], [UserEmail])
values (0, 0, 'Integra', '1/19/2022', 'test@example.com'),
(1, 1, 'Encore', '1/19/2022', 'test@example.com'),
(2, 2, '300C', '1/19/2022', 'test@example.com')
set identity_insert [Model] off;

-- BodyStyle
set identity_insert [BodyStyle] on;
insert into [BodyStyle] ([BodyStyleId], [Name])
values (0, 'Sedan'),
(1, 'Wagon'),
(2, 'SUV'),
(3, 'Truck'),
(4, 'Van')
set identity_insert [BodyStyle] off;

-- Transmission
set identity_insert [Transmission] on;
insert into [Transmission] ([TransmissionId], [Name])
values (0, 'Automatic'),
(1, 'Manual')
set identity_insert [Transmission] off;

-- Type
set identity_insert [Type] on;
insert into [Type] ([TypeId], [Name])
values (0, 'New'),
(1, 'Used')
set identity_insert [Type] off;

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

-- Interior
set identity_insert [Interior] on;
insert into [Interior] ([InteriorId], [Name])
values (0, 'Black'),
(1, 'White'),
(2, 'Beige'),
(3, 'Gray')
set identity_insert [Interior] off;

-- State
insert into [State] ([StateId], [Name])
values ('MN', 'Minnesota'),
('OH', 'Ohio'),
('KY', 'Kentucky'),
('WI', 'Wisconsin'),
('IL', 'Illinois'),
('IN', 'Indiana')

-- PurchaseType
set identity_insert [PurchaseType] on;
insert into [PurchaseType] ([PurchaseTypeId], [Name])
values (0, 'Bank Finance'),
(1, 'Cash'),
(2, 'Dealer Finance')
set identity_insert [PurchaseType] off;

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

-- Order
set identity_insert [Order] on;
insert into [Order] ([OrderId], [Name], [Email], [Phone], [StreetOne], [City], [Zipcode], [PurchasePrice], [UserEmail], [CarId], [PurchaseTypeId], [StateId], [DateAdded])
values (0, 'Jane Doe', 'janedoe@example.com', '5551234567', '123 Main Street', 'Minneapolis', '55401', 19500, 'test@example.com', 1, 0, 'MN', '1/19/2022'),
(1, 'John Smith', 'johnsmith@example.com', '5559876543', '321 Main Street', 'Minneapolis', '55401', 9500, 'test@example.com', 3, 0, 'MN', '1/19/2022')
set identity_insert [Order] off;

-- Special
set identity_insert [Special] on;
insert into [Special] ([SpecialId], [Title], [Description])
values (0, 'Example Special', 'Lorem ipsum dolor sit amet, et cetera')
set identity_insert [Special] off;

-- Contact
set identity_insert [Contact] on;
insert into [Contact] ([ContactId], [Name], [Email], [Phone], [Message])
values (0, 'Jane Doe', 'janedoe@example.com', '5551234567', 'I would like to negotiate the price for this Acura Integra')
set identity_insert [Contact] off;

-- Roles
insert into [AspNetRoles] ([Id], [Name])
values (0, 'Admin'),
(1, 'Sales'),
(2, 'Disabled')

-- Users
insert into [AspNetUsers] ([Id], [Email], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [AccessFailedCount], [LockoutEnabled], [FirstName], [LastName])
values ('00000000-0000-0000-0000-000000000000', 'testSales@example.com', 'testSales@example', 0, 0, 0, 0, 0, 'Admin', 'Test'),
('11111111-1111-1111-1111-111111111111', 'testAdmin@example.com', 'testAdmin@example.com', 0, 0, 0, 0, 0, 'Sales', 'Test'),
('22222222-2222-2222-2222-222222222222', 'testDisabled@example.com', 'testDisabled@example.com', 0, 0, 0, 0, 0, 'Disabled', 'Test'),
('33333333-3333-3333-3333-333333333333', 'test@example.com', 'testOne@example.com', 0, 0, 0, 0, 0, 'One', 'Test'),
('44444444-4444-4444-4444-444444444444', 'testTwo@example.com', 'testTwo@example.com', 0, 0, 0, 0, 0, 'Two', 'Test'),
('55555555-5555-5555-5555-555555555555', 'testThree@example.com', 'testThree@example.com', 0, 0, 0, 0, 0, 'Three', 'Test'),
('66666666-6666-6666-6666-666666666666', 'testFour@example.com', 'testFour@example.com', 0, 0, 0, 0, 0, 'Four', 'Test')

--UserRoles
insert into [AspNetUserRoles] ([UserId], [RoleId])
values ('00000000-0000-0000-0000-000000000000', 1),
('11111111-1111-1111-1111-111111111111', 0),
('22222222-2222-2222-2222-222222222222', 2),
('33333333-3333-3333-3333-333333333333', 1),
('44444444-4444-4444-4444-444444444444', 1),
('55555555-5555-5555-5555-555555555555', 1),
('66666666-6666-6666-6666-666666666666', 1)

end
go

-- Sample Users
-- Email: testAdmin@example.com
-- Pass: Password123!
-- Email: testSales@example.com
-- Pass: Password123!