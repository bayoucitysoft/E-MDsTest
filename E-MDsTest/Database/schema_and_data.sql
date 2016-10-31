if exists(select * from sys.objects where name = 'People') 
begin drop table People end 
go
create table People
(
	id bigint identity(1,1),
	first_name nvarchar(64),
	last_name nvarchar(65),
	gender nvarchar(6),
	dob date 
)
go
--insert test data 
insert into People 
(first_name, last_name, gender, dob)
values 
('John', 'Smith', 'male', CAST('1955-08-20' as date)),
('France', 'Kindrick', 'female', CAST('1975-12-04' as date)),
('Demetrice', 'Strouth', 'female', CAST('1955-08-20' as date)),
('Gale', 'Boothby', 'female', CAST('1980-09-15' as date)),
('Delphia', 'Kwan', 'female', CAST('1965-04-10' as date)),
('Kia', 'Garbett', 'female',CAST('1995-11-23' as date)),
('Lita', 'Melcher', 'female',CAST('1987-01-02' as date)),
('Jamee', 'Hogle', 'female',CAST('1977-05-14' as date)),
('Ida', 'Tookes', 'male',CAST('1978-12-24' as date)),
('Saran', 'Stipe', 'female',CAST('1985-06-05' as date)),
('Mahalia', 'Nord', 'female',CAST('1956-11-02' as date)),
('Gordon', 'Copas', 'male',CAST('1978-07-11' as date)),
('Marlin', 'Leija', 'female',CAST('1966-05-13' as date)),
('Kizzie', 'Puente', 'female',CAST('1978-02-23' as date)),
('Ling', 'Such', 'male',CAST('1985-08-26' as date)),
('Mellisa', 'Blanca', 'female',CAST('1975-02-21' as date)),
('Carylon', 'Merz', 'female',CAST('1978-12-05' as date)),
('Shawanna', 'Weber', 'female',CAST('1965-02-01' as date)),
('Reagan', 'Waxman', 'male',CAST('1955-08-20' as date)),
('Freda', 'Felker', 'female',CAST('1975-04-05' as date)),
('Inge', 'Maier', 'female',CAST('1989-08-06' as date))
go
if exists(select * from sys.objects where name = 'GetPeople')
begin drop procedure GetPeople end
go
create procedure GetPeople
as
begin
	select id, 
	first_name, 
	last_name, 
	gender, 
	dob 
	from People with(nolock) 
end
go
exec GetPeople 