using Clockwork.Web.Services;
using X.PagedList;
using System.Web.Mvc;
using Clockwork.Web.Models;
using System;
using System.Linq;

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
            var pagedList = _timeInquiryService.GetAll(pageNumber, PAGE_SIZE);
            ViewBag.TimeInquiryPage = new StaticPagedList<TimeInquiryModel>(pagedList.PageItems, pageNumber, PAGE_SIZE, pagedList.TotalItemsCount);

            var vm = new TimeInquiryViewModel();
            vm.SelectedTimeZoneInfoStandardName = ViewBag.SelectedTimeZoneInfoStandardName ?? TimeZoneInfo.Local.StandardName;
            return View(vm);
        }

        // POST: TimeInquiries/Create
        [HttpPost]
        public ActionResult Post(FormCollection collection)
        {
            var selectedTimeZoneInfoStandardName = collection["SelectedTimeZoneInfoStandardName"];
            try
            {
                _timeInquiryService.Create(ViewBag.SelectedTimeZoneInfoStandardName);
            }
            catch { }

            return RedirectToAction("Index", new { SelectedTimeZoneInfoStandardName = selectedTimeZoneInfoStandardName });
        }
    }
}
