using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Clockwork.Web.Shared
{
    public static class SharedHttpClient
    {
        private static HttpClient _httpClient;

        public static HttpClient Instance
        {
            get
            {
                if (_httpClient == null)
                    _httpClient = new HttpClient();

                return _httpClient;
            }
        }
    }
}