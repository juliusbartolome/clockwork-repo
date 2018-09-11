using Clockwork.API.Controllers;
using Clockwork.Domain.Entities;
using Clockwork.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Clockwork.API.Tests.Controllers
{
    [TestClass]
    public class TimeInquiriesControllerTest
    {
        private Mock<ITimeInquiryService> _mockedTimeInquiryService;
        private Mock<ILogger<TimeInquiriesController>> _mockedLogger;
        private TimeInquiriesController _sutController;
        [TestInitialize]
        public void TestInitialize()
        {
            _mockedTimeInquiryService = new Mock<ITimeInquiryService>();
            _mockedLogger = new Mock<ILogger<TimeInquiriesController>>();
            _sutController = new TimeInquiriesController(_mockedTimeInquiryService.Object, _mockedLogger.Object);
        }

        [TestMethod]
        public void GetById_WhenPassedWith_NullId_ShouldReturnBadRequest()
        {
            var result = _sutController.GetById(null);

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [TestMethod]
        public void GetById_WhenPassedWith_ValidId_ShouldCallTimeInquiryServiceOnce()
        {
            var validId = 1;

            _sutController.GetById(validId);

            _mockedTimeInquiryService.Verify(service => service.GetById(It.Is<int>(id => id == validId)), Times.Once());
        }

        [TestMethod]
        public void GetById_WhenPassedWith_ValidId_ShouldReturnMockedTimeInquiryEntity()
        {
            var mockedEntity = new TimeInquiryEntity
            {
                Id = 1,
                IpAddress = ":::1",
                TimeZoneInfoId = TimeZoneInfo.Local.Id,
                UtcDateTime = DateTime.UtcNow
            };

            _mockedTimeInquiryService.Setup(service => service.GetById(It.IsAny<int>())).Returns(mockedEntity);

            var result = _sutController.GetById(1);
            Assert.AreEqual(mockedEntity, result);
        }
    }
}
