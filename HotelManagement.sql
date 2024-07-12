IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Rooms')
	CREATE TABLE Rooms (
		room_id INT IDENTITY(1,1) NOT NULL,
		room_number INT NOT NULL, 
		room_type NVARCHAR(50) NOT NULL,
		price_per_night INT NOT NULL,
		availability BIT NOT NULL,

		CONSTRAINT PK_rooms_room_id PRIMARY KEY (room_id)
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customers')
	CREATE TABLE Customers (
		customer_id INT IDENTITY(1,1) NOT NULL,
		first_name NVARCHAR(50) NOT NULL, 
		last_name NVARCHAR(50) NOT NULL,
		email NVARCHAR(50) NOT NULL,
		phone_number VARCHAR(50) NOT NULL,

		CONSTRAINT PK_Customers_customer_id PRIMARY KEY (customer_id)
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Bookings')
	CREATE TABLE Bookings (
		booking_id INT IDENTITY(1,1) NOT NULL,
		customer_id INT NOT NULL,
		room_id INT NOT NULL,
		check_in_date DATE NOT NULL, 
		check_out_date DATE NOT NULL,

		CONSTRAINT PK_Booking_booking_id PRIMARY KEY (booking_id),

		CONSTRAINT FK_booking_customer_id
			FOREIGN KEY (customer_id) REFERENCES Customers (customer_id),
		CONSTRAINT FK_booking_room_id
			FOREIGN KEY (room_id) REFERENCES Rooms (room_id)
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Facilities')
	CREATE TABLE Facilities (
		facility_id INT IDENTITY(1,1) NOT NULL,
		facility_name NVARCHAR(50) NOT NULL, 

		CONSTRAINT PK_Facilities_facility_id PRIMARY KEY (facility_id)
);

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='RoomsToFacilities')
	CREATE TABLE RoomsToFacilities (
		room_id INT NOT NULL,
		facility_id INT NOT NULL,

		CONSTRAINT PK_RoomsToFacilities_room_id PRIMARY KEY (room_id),

		CONSTRAINT FK_RoomsToFacilities_facility_id
			FOREIGN KEY (facility_id) REFERENCES Facilities (facility_id),
		CONSTRAINT FK_RoomsToFacilities_room_id
			FOREIGN KEY (room_id) REFERENCES Rooms (room_id)
);

--«аполните таблицы данными, предполага€ следующее:
--  ¬ таблице "Rooms" добавьте информацию о нескольких номерах разных типов (одноместные, двухместные и т. д.) 
--  с разными ценами и доступностью.
INSERT INTO Rooms (room_number, room_type, price_per_night, availability)
VALUES
	(10, 'single', 2400, 1),
	(223, 'double', 3500, 0),
	(15, 'standard', 2700, 0),
	(204, 'studio', 5700, 0),
	(100, 'suite', 6000, 0),
	(150, 'suite', 8000, 1);

-- ¬ таблице "Customers" добавьте информацию о нескольких клиентах с их именами, электронными адресами и номерами телефонов.
INSERT INTO Customers (first_name, last_name, email, phone_number)
VALUES
	('Artem', 'Petrov', 'petrov.art@mail.ru', '89273456573'),
	('Ilya', 'Ivanov', 'ivanov.ilya@mail.ru', '89272033456'),
	('Vadim', 'Kotov','kotv@mail.ru', '89048963231'),
	('Roman', 'Stepanov', 'stepanovrom@mail.ru', '89102849339');

-- ¬ таблице "Bookings" добавьте информацию о нескольких бронировани€х, св€зав их с соответствующими клиентами и номерами.
INSERT INTO Bookings (customer_id, room_id, check_in_date, check_out_date)
VALUES
	(4, 5, '2024-08-10', '2024-08-16'),
	(3, 1, '2024-07-9', '2024-07-25'),
	(1, 4, '2024-10-15', '2024-10-18'),
	(2, 3, '2024-09-05', '2024-09-19'),
	(2, 1, '2024-11-06', '2024-11-09'),
	(2, 4, '2024-12-10', '2024-12-15'),
	(4, 6, '2024-07-11', '2024-07-23');

-- ¬ таблице "RoomFacilities" добавьте информацию о различных удобствах номеров (Wi-Fi, кондиционер, мини-бар и т. д.).
INSERT INTO Facilities (facility_name)
VALUES
	('Wi-Fi'),
	('air conditioner'),
	('jacuzzi'),
	('kitchen nook'),
	('mini fridge'),
	('minibar');


-- ¬ таблице "RoomFacilitiesMapping" укажите, какие удобства доступны в каких номерах.
INSERT INTO RoomsToFacilities (room_id, facility_id)
VALUES
	(1, 6),
	(2, 2),
	(3, 5),
	(4, 4);

-- Ќайдите все доступные номера дл€ бронировани€ сегодн€.
SELECT * 
	FROM Rooms
	WHERE availability = 0;

-- Ќайдите всех клиентов, чьи фамилии начинаютс€ с буквы "S".
SELECT * 
	FROM Customers
	WHERE last_name LIKE 'S%';

-- Ќайдите все бронировани€ дл€ определенного клиента (по имени или электронному адресу).
SELECT * 
	FROM Bookings
	LEFT JOIN Customers
	ON Bookings.customer_id = Customers.customer_id
	WHERE first_name = 'Ivanov';

-- Ќайдите все бронировани€ дл€ определенного номера.
SELECT * 
	FROM Bookings
	LEFT JOIN Rooms
	ON Bookings.room_id = Rooms.room_id
	WHERE Bookings.room_id = 4;

-- Ќайдите все номера, которые не забронированы на определенную дату.
SELECT * 
	FROM Bookings
	WHERE NOT (check_in_date < GETDATE() 
	AND check_out_date > GETDATE());