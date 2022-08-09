create database AeropuertoDB
go
use AeropuertoDB
go
create table [User]
(
	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Username nvarchar (50) unique not null,
	[Password] nvarchar (100) not null,
	[Name]nvarchar (50) not null,
	LastName nvarchar (50) not null,
	Email  nvarchar (100) unique not null
)
go
insert into [User] values (NEWID(), 'admin', 'admin','Mich','Ric', 'mich9111@hotmail.com')
insert into [User] values (NEWID(), 'mauricio', '122345','sadsad','sadad', 'addasd@hotmail.com')
insert into [User] values (NEWID(), 'keni', 'asdfg','asd fasdad','asd', 'ksad@gmail.com')
go

select *from [User]