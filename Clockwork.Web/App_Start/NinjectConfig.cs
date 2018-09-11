using Clockwork.Web.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clockwork.Web
{
    public class NinjectConfig
    {
        public static void RegisterBindings()
        {
            var kernel = new StandardKernel();

            kernel.Bind<ITimeInquiryService>().To<TimeInquiryService>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}