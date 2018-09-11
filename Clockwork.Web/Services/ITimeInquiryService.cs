using Clockwork.Web.Models;

namespace Clockwork.Web.Services
{
    public interface ITimeInquiryService
    {
        TimeInquiryModel Create(string timeZoneInfoId);
        PagedResult<TimeInquiryModel> GetAll(int pageNumber, int pageSize);
        TimeInquiryModel GetById(int id);
    }
}