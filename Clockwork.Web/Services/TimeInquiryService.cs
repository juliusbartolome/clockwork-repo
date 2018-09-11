using Clockwork.Web.Models;
using Clockwork.Web.Shared;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Clockwork.Web.Services
{
    public class TimeInquiryService : ITimeInquiryService
    {
        private const string BASE_API_URL = "http://localhost:50594/api/timeinquiries/";

        public PagedResult<TimeInquiryModel> GetAll(int pageNumber, int pageSize)
        {
            var url = $"{BASE_API_URL}?pageNumber={pageNumber}&pageSize={pageSize}";
            var responseJson = SharedHttpClient.Instance.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<PagedResult<TimeInquiryModel>>(responseJson);
        }

        public TimeInquiryModel Create(string timeZoneInfoId)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new TimeInquiryModel { TimeZoneInfoId = timeZoneInfoId }), Encoding.UTF8, "application/json");
            var response = SharedHttpClient.Instance.PostAsync(BASE_API_URL, content).Result;

            if (!response.IsSuccessStatusCode)
                return null;

            var responseJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TimeInquiryModel>(responseJson);
        }

        public TimeInquiryModel GetById(int id)
        {
            var url = $"{BASE_API_URL}{id}";
            var responseJson = SharedHttpClient.Instance.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<TimeInquiryModel>(responseJson);
        }
    }
}