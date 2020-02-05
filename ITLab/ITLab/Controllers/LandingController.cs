using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITLab.Models;
using ITLab.Client_Objects;
using System.Globalization;


namespace ITLab.Controllers
{
    public class LandingController : Controller
    {
        private readonly ITLabContext _context;

        public LandingController(ITLabContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<ShortNews> news = await _context.ShortNews.FromSqlRaw("select News.id as Id, News.title as Title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount, Count(Comments.Id) as CommentsCount from News full join Comments on Comments.NewsId = News.id group by News.id, News.title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount").ToListAsync();

            return View(news);
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
                responseStatus.Exception = ex.ToString();
            }

            return responseStatus;

        }
        public ActionResult<List<News>> test()
        {
            var test = _context.News
                .Include(s => s.Comments)
                .ToList();

            return test;
        }
        public async Task<IActionResult> News()
        {
            List<ShortNews> news = await _context.ShortNews.FromSqlRaw("select News.id as Id, News.title as Title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount, Count(Comments.Id) as CommentsCount from News full join Comments on Comments.NewsId = News.id group by News.id, News.title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount").ToListAsync();
            return View(news);
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
        public IActionResult FullNews(int Id)
        {

            try
            {
                var fullNews = _context.News.Where(i => i.Id == Id)
              .Join(_context.Photos, news => news.Id, photos => photos.NewsId,
              (news, photos) => new { news, photos })
              .Select(i => new FullNews
              {
                  Id = i.news.Id,
                  Title = i.news.Title,
                  FullDescription = i.news.FullDescription,
                  TimeDate = i.news.TimeDate,
                  ViewsCount = i.news.ViewsCount,
                  CommentsCount = _context.Comments.Where(n => n.NewsId == Id).Count(),
                  Photos = _context.Photos.Where(n => n.NewsId == Id).ToList(),
                  Videos = _context.Videos.Where(n => n.NewsId == Id).ToList(),
                  Comments = _context.Comments.Where(n => n.NewsId == Id).ToList()
              }).First();
                fullNews.ShortNews = _context.ShortNews.FromSqlRaw("select News.id as Id, News.title as Title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount, Count(Comments.Id) as CommentsCount from News full join Comments on Comments.NewsId = News.id group by News.id, News.title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount").ToList();
              

                return View(fullNews);
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
        public async Task<IActionResult> ShortNews()
        {
            List<ShortNews> news = await _context.ShortNews.FromSqlRaw("select News.id as Id, News.title as Title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount, Count(Comments.Id) as CommentsCount from News full join Comments on Comments.NewsId = News.id group by News.id, News.title, News.ShortDescription, News.FullDescription, News.TimeDate, News.HeadPhoto, News.ViewsCount").ToListAsync();
            return PartialView(news);
        }
        [HttpPost]
        public List<Comments> Comments(int NewsId)
        {
            var comments = _context.Comments.Where(n => n.NewsId == NewsId).ToList();
            return comments;
        }
       
    }
}

