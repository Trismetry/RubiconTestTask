create database RubiconDB


use RubiconDB

create table Rectangles
(
Id int not null identity(1,1) primary key,
[Left] float not null,
[Right] float not null, 
[Top] float not null, 
[Bottom] float not null
)


insert into Rectangles([Left], [Right], [Top], [Bottom])
values (1.21, 2.33, 4.1, 5.2)
