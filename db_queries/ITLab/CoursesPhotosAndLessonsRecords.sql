USE [ITLab_Cabinet];
GO
INSERT INTO [dbo].[Photos]
([Name], 
 [Description], 
 [TimeStamp], 
 [PhotoLink], 
 [LessonId], 
 [CourseId]
)
VALUES
('Photo 1', 
 'Some description here!', 
 '2020-08-23', 
 'https://www.pxwall.com/wp-content/uploads/2018/03/4K-Background-3840x2160.jpg', 
 NULL, 
 NULL
),
('Photo 2', 
 'Some description here!', 
 '2020-08-23', 
 'https://img5.goodfon.com/wallpaper/nbig/a/bf/geirangerfjord-priroda-peizazh-norvegiia-ford-vodopad-gory-g.jpg', 
 NULL, 
 NULL
),
('Photo 3', 
 'Some description here!', 
 '2020-08-23', 
 'https://norway.nordicvisitor.com/images/norway/seven-sisters-waterfall-geiranger-norway-(2).jpg', 
 NULL, 
 NULL
);

GO

INSERT INTO [dbo].[Courses]
([Name], 
 [Description], 
 [HeadPhotoId]
)
VALUES
('Course 1', 
 'Some info here!', 
 1
),
('Course 2', 
 'Some info here!', 
 2
),
('Course 3', 
 'Some info here!', 
 3
);

GO

INSERT INTO [dbo].[Lessons]
([Name], 
 [Description], 
 [CourseId], 
 [LessonDateFrom], 
 [LessonDateTo]
)
VALUES
('Lesson 1', 
 'Some description here!', 
 1, 
 '2020-08-23 14:00', 
 '2020-08-23 16:30'
),
('Lesson 2', 
 'Some description here!', 
 1, 
 '2020-08-23 17:00', 
 '2020-08-23 18:30'
),
('Lesson 1', 
 'Some description here!', 
 2, 
 '2020-08-26 14:00', 
 '2020-08-26 16:30'
),
('Lesson 2', 
 'Some description here!', 
 2, 
 '2020-08-26 17:00', 
 '2020-08-26 18:30'
),
('Lesson 1', 
 'Some description here!', 
 3, 
 '2020-08-28 14:00', 
 '2020-08-28 16:30'
),
('Lesson 2', 
 'Some description here!', 
 3, 
 '2020-08-28 17:00', 
 '2020-08-28 18:30'
);
GO