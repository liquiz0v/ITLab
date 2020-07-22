using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITLab.Models;
using ITLab.Client_Objects;
using System.Globalization;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Net.Http;
using ITLab.Landing.MVC.Client_Objects;
using Microsoft.Extensions.Configuration;

namespace ITLab.Controllers
{
    public class LandingController : Controller
    {
        private readonly ITLabContext _context;
        private static IConfiguration _configuration;

        string connectionString = _configuration.GetConnectionString("DefaultConnection");

        //string connectionString = "Server=.;Database=ITLab_Landing; Trusted_Connection=True; MultipleActiveResultSets=true";
        public LandingController(ITLabContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Project()
        {
            return View();
        }

        [HttpPost]
        public object GetNews(int newsId)
        {
            var query = @"
            select 
                News.id as Id, 
                News.title as Title, 
                News.ShortDescription, 
                News.FullDescription, 
                News.TimeDate, 
                News.HeadPhoto, 
                News.ViewsCount, 
                Count(Comments.Id) as CommentsCount 
            from News 
                full join Comments on Comments.NewsId = News.id 
            group by 
                News.id, 
                News.title, 
                News.ShortDescription, 
                News.FullDescription, 
                News.TimeDate, 
                News.HeadPhoto,
                News.ViewsCount";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<ShortNews>(query).ToList();
            }
        }

        [HttpPost]
        public ActionResult<ResponseStatus> FeedBack(string FullName, string Phone, string Question)
        {

            ResponseStatus responseStatus = new ResponseStatus { Response = false };

            try
            {
                Feedback feedback = new Feedback()
                {
                    FullName = FullName,
                    Phone = Phone,
                    Question = Question,
                    FeedbackStatus = 1
                };

                _context.Feedback.Add(feedback);
                _context.SaveChanges();
                responseStatus.Response = true;
            }
            catch (Exception ex)
            {
                responseStatus.Exception = ex.Message;
            }

            return responseStatus;

        }

        public object GetShortNews()
        {
            var query = @"
            select 
                News.id as Id, 
                News.title as Title, 
                News.ShortDescription, 
                News.FullDescription, 
                News.TimeDate, 
                News.HeadPhoto, 
                News.ViewsCount, 
                Count(Comments.Id) as CommentsCount 
            from News 
                full join Comments on Comments.NewsId = News.id 
            group by News.id, 
                News.title, 
                News.ShortDescription, 
                News.FullDescription, 
                News.TimeDate, 
                News.HeadPhoto, 
                News.ViewsCount";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<ShortNews>(query).ToList();
            }
        }
        [HttpPost]
        public ResponseStatus NewsSubscr(string Email)
        {
            ResponseStatus responseStatus = new ResponseStatus() { Response = true };

            try
            {
                Subscriptions subscriptions = new Subscriptions() { Email = Email };
                _context.Subscriptions.Add(subscriptions);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                responseStatus.Response = false;
                responseStatus.Exception = ex.Message;
                return responseStatus;
            }
            return responseStatus;
        }
        public IActionResult Cources()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FullNews(int newsId) //move to queries
        {
            return View();
        }

        [HttpGet]
        public object GetFullNews(int newsId) //move to queries
        {
            try
            {
                var news = new News();
                var query = @$"
                    SELECT [id]
                          ,[title]
                          ,[ShortDescription]
                          ,[FullDescription]
                          ,[TimeDate]
                          ,[HeadPhoto]
                          ,[ViewsCount]
                      FROM [ITLab_Landing].[dbo].[News] 
                        where id = {newsId}";
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    news = db.Query<News>(query).FirstOrDefault();
                }
                var videos = new List<Videos>();
                var videosQuery = @$"
                      select [id]
                          ,[Link]
                          ,[NewsId] 
                      from Videos 
                      where NewsId = {newsId}";
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    videos = db.Query<Videos>(videosQuery).ToList();
                }


                var photos = new List<Photos>();
                var photosQuery = @$"
                      select[id]
                        ,[Link]
                        ,[NewsId]
                      from Photos
                      where NewsId = {newsId}";
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    photos = db.Query<Photos>(photosQuery).ToList();
                }
                
                var comments = new List<CommentsDTO>();
                var commentsQuery = @$"
                    select Users.FullName
                        ,Comments.CommentText
                        ,Comments.TimeDate
                        ,Comments.CommentatorId
                        ,Comments.NewsId
                    from Comments
                    join Users on Users.Id = Comments.CommentatorId
                    where Comments.NewsId = {newsId};";

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    comments = db.Query<CommentsDTO>(commentsQuery).ToList();
                }

                var fullnews = new FullNewsDTO
                {
                    Id = news.Id,
                    Title = news.Title,
                    FullDescription = news.FullDescription,
                    TimeDate = news.TimeDate,
                    ViewsCount = news.ViewsCount,
                    Comments = comments,
                    Videos = videos,
                    Photos = photos,
                    CommentsCount = comments.Count()
                };
                return fullnews;
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        [HttpPost]
        public ResponseStatus CreateComment(string CommentText, int CommentatorId, int NewsId)
        {

            ResponseStatus responseStatus = new ResponseStatus() { Response = false };

            try
            {
                Comments comments = new Comments()
                {
                    CommentText = CommentText,
                    CommentatorId = CommentatorId,
                    NewsId = NewsId
                };
                _context.Comments.Add(comments);
                _context.SaveChanges();
                responseStatus.Response = true;
                return responseStatus;
            }
            catch (Exception ex)
            {
                responseStatus.Exception = ex.Message;
                return responseStatus;
            }
        }

        public IActionResult Contacts()
        {
            return View();
        }
        public async Task<object> ShortNews() // move to queries 
        {

            var query = @"
                select 
                    News.id as Id, 
                    News.title as Title, 
                    News.ShortDescription, 
                    News.FullDescription, 
                    News.TimeDate, 
                    News.HeadPhoto, 
                    News.ViewsCount, 
                    Count(Comments.Id) as CommentsCount 
                from News 
                    full join Comments on Comments.NewsId = News.id
                group by 
                    News.id, 
                    News.title, 
                    News.ShortDescription, 
                    News.FullDescription, 
                    News.TimeDate, 
                    News.HeadPhoto, 
                    News.ViewsCount";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<ShortNews>(query).ToList();
            }
        }

        [HttpPost]
        public IActionResult Comments(int newsId) //move to queries
        {
            return View();
        }

        [HttpPost]
        public List<Comments> GetComments(int newsId) //move to queries
        {
            var comments = new List<Comments>();
            var commentsQuery = @$"
                    Select 
                      [Id]
                      ,[CommentText]
                      ,[TimeDate]
                      ,[CommentatorId]
                      ,[NewsId]
                   from Comments 
                   where NewsId = {newsId}";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                comments = db.Query<Comments>(commentsQuery).ToList();
            }
            return comments;
        }

    }
}

