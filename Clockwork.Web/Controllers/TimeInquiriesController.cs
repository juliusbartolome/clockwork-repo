using Clockwork.Web.Services;
using X.PagedList;
using System.Web.Mvc;

namespace Clockwork.Web.Controllers
{
    public class TimeInquiriesController : Controller
    {
        private readonly ITimeInquiryService _timeInquiryService;
        private const int PAGE_SIZE = 25;
        public TimeInquiriesController(ITimeInquiryService timeInquiryService)
        {
            _timeInquiryService = timeInquiryService;
        }

        // GET: TimeInquiries
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            ViewBag.TimeInquiryPage = _timeInquiryService.GetAll(pageNumber, PAGE_SIZE).PageItems.ToPagedList(1, PAGE_SIZE);

            return View();
        }

        // GET: TimeInquiries/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeInquiries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeInquiries/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeInquiries/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimeInquiries/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeInquiries/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeInquiries/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
