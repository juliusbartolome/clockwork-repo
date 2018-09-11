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
            vm.SelectedTimeZoneInfoId = ViewBag.SelectedTimeZoneInfoId ?? TimeZoneInfo.Local.Id;
            return View(vm);
        }

        // POST: TimeInquiries/Create
        [HttpPost]
        public ActionResult Post(FormCollection collection)
        {
            var selectedTimeZoneInfoId = collection["SelectedTimeZoneInfoId"];
            try
            {
                _timeInquiryService.Create(selectedTimeZoneInfoId);
            }
            catch { }

            return RedirectToAction("Index", new { SelectedTimeZoneInfoId = selectedTimeZoneInfoId });
        }
    }
}
