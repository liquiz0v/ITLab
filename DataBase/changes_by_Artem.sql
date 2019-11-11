use ITLab;
go
alter table News
add TimeDate DateTime
go 
alter table News
add HeadPhoto nvarchar(max)
go
alter table News
add ViewsCount int
go
alter table News alter column ShortDescription nvarchar(max)
go
create table Users(
Id int identity primary key not null,
FullName nvarchar(max)
);
go
create table Comments
(
Id int identity primary key not null,
CommentText nvarchar(max),
TimeDate DateTime not null,
CommentatorId int foreign key references Users(Id),
NewsId int foreign key references News(Id)
);