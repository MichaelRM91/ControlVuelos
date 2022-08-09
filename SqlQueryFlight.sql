create database AeropuertoDB
go
use AeropuertoDB
go
create table [Flights]
(

	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Origen nvarchar (50)  not null,
	Destino nvarchar (50) not null,
	Fecha nvarchar (50) not null,
	Salida nvarchar (50) not null,
	Llegada  nvarchar (50)  not null,
    NumVuelo nvarchar (50)  not null,
	Aerolinea nvarchar (50) not null,
	Estado nvarchar (50) not null,

)
go
insert into [Flights] values (NEWID(), 'Cali', 'Bogota','07/08/2022','12:00','12:30', 'AV47', 'Avianca', 'Cancelado')
insert into [Flights] values (NEWID(), 'Cali', 'Medellin','05/09/2022','1:00','2:00', 'VA80', 'VivaAir', 'Cancelado')
insert into [Flights] values (NEWID(), 'Cali', 'Cartagena','12/07/2022','14:00','16:00', 'LT35', 'Latan', 'disponible')
insert into [Flights] values (NEWID(), 'Cali', 'Santa Marta','27/08/2022','15:00','18:00', 'CP56', 'Copa', 'disponible')
go

select *from [Flights]

