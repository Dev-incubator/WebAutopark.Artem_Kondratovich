CREATE DATABASE WebAutoparkDb

USE WebAutoparkDb

CREATE TABLE [Components]
(
	[ComponentId] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED([ComponentId] ASC)
)

CREATE TABLE [VehicleTypes]
(
	[VehicleTypeId] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[TaxCoefficient] FLOAT NOT NULL,

	CONSTRAINT [PK_VehicleTypes] PRIMARY KEY CLUSTERED([VehicleTypeId] ASC)
)

CREATE TABLE [Vehicles]
(
	[VehicleId] INT NOT NULL IDENTITY(1,1),
	[VehicleTypeId] INT NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[RegistrationNumber] NVARCHAR(10) NOT NULL,
	[Weight] FLOAT NOT NULL,
	[YearIssue] INT NOT NULL,
	[Mileage] FLOAT NOT NULL,
	[Color] INT NOT NULL,
	[FuelConsumption] FLOAT NOT NULL,

	CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED([VehicleId] ASC),
	CONSTRAINT [FK_Vehicles_VehicleTypes] FOREIGN KEY([VehicleTypeId]) REFERENCES [VehicleTypes]([VehicleTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE [Orders]
(
	[OrderId] INT NOT NULL IDENTITY(1,1),
	[VehicleId] INT NOT NULL,
	[Date] DATETIME NOT NULL,

	CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED([OrderId] ASC),
	CONSTRAINT [FK_Orders_Vehicles] FOREIGN KEY([VehicleId]) REFERENCES [Vehicles]([VehicleId]) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE [OrderItems]
(
	[OrderItemId] INT NOT NULL IDENTITY(1,1),
	[OrderId] INT NOT NULL,
	[ComponentId] INT NOT NULL,
	[Quantity] INT NOT NULL,

	CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED([OrderItemId] ASC),
	CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderId]) REFERENCES [Orders]([OrderId]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_OrderItems_Components] FOREIGN KEY([ComponentId]) REFERENCES [Components]([ComponentId]) ON DELETE CASCADE ON UPDATE CASCADE
)