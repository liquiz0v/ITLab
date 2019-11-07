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
        public ActionResult<ResponseStatus> FeedBack([Bind("FullName,Phone,Question")] Feedback feedback)
        {
            ResponseStatus responseStatus = new ResponseStatus { Response = false };
            if (ModelState.IsValid)
            {
                try
                {
                    feedback.FeedbackStatus = 1;
                    _context.Feedback.Add(feedback);
                    _context.SaveChanges();
                    responseStatus.Response = true;
                }
                catch (Exception ex)
                {
                    responseStatus.Exception = ex.ToString();
                }
                
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
       
    }
}