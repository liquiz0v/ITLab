create database ITLab;
use ITLab;

create table ITLab.News(
    id int primary key identity not null,
    title nvarchar(50),
    ShortDescription nvarchar(100),
    FullDescription nvarchar(max)
);

create table ITLab.Photos(
    id int primary key identity not null,
    Link nvarchar(max),
    NewsId int FOREIGN key references News(Id) default null,
);

create table ITLab.Videos(
    id int primary key identity not null,
    Link nvarchar(max),
    NewsId int FOREIGN key references News(Id) default null
);

/* TEXTS - НЕ НУЖНО ПИСАТЬ */

create table ITLab.FeedbackStatuses(
    id int primary key identity not null,
    Statuses nvarchar(50) not NULL
);

insert into FeedbackStatuses(Statuses) values ('Not processed'), ('Processed');

create table ITLab.Feedback(
    id int primary key identity not null,
    FullName nvarchar(100),
    Phone nvarchar(50),
    Question nvarchar(max),
    FeedbackStatus int FOREIGN key REFERENCES FeedbackStatuses(Id) default 1
);