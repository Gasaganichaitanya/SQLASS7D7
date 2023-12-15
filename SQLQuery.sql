create database Ass7LibraryDB

use Ass7LibraryDB
 
 create table Books(
 BookId int primary key,
 Title nvarchar(100),
 Author nvarchar(100),
 Genre nvarchar(50),
 Quantity int not null
 )

 insert into Books values (1,'The History of Tom Jones','Henry Fielding','Drama',2)
  insert into Books values (2,'Pride and Prejudice',' jane Austen','Action',1)
   insert into Books values (3,' Believe   ',' Suresh Rain','Biography',3)
   insert into Books values (4,'The Red and the Black',' Stendal','Drama',2)

   select * from Books