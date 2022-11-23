using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Faqs.Models;

namespace Faqs.Controllers
{
    public class HomeController : Controller
    {
        private FaqsContext context { get; set; }
        public HomeController(FaqsContext ctx)
        {
            context = ctx;
        }

        [Route("topic/{topic}/category/{category}")]
        [Route("topic/{topic}")]
        [Route("category/{category}")]
        [Route("/")]
        public IActionResult Index(string topic, string Category)
        {
            ViewBag.Topics = context.Topics.OrderBy(t => t.Name).ToList();
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            ViewBag.SelectedTopic = topic;

            IQueryable<Faq> faqs = context.FAQs
                .Include(f => f.Topic)
                .Include(f => f.Category)
                .OrderBy(f => f.Question);

            if (!string.IsNullOrEmpty(topic))
            {
                faqs = faqs.Where(f => f.TopicId == topic);
            }
            if (!string.IsNullOrEmpty(Category))
            {
                faqs = faqs.Where(f => f.CategoryId == Category);
            }

            return View(faqs.ToList());

        }
    }
}