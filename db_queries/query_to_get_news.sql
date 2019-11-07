use ITLab;
select News.id as Id, News.title as Title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount, Count(Comments.Id) as CommentsCount
from News
full join Comments on Comments.NewsId = News.id
group by News.id, News.title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount