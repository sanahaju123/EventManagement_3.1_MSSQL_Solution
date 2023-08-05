using EventManagement.BusinessLayer.Interfaces;
using EventManagement.BusinessLayer.Services.Repository;
using EventManagement.BusinessLayer.Services;
using EventManagement.BusinessLayer.ViewModels;
using EventManagement.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using EventManagaement.Tests.TestCases;

namespace PoliticalParties.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IEventServices _eventServices;
        public readonly Mock<IEventRepository> eventservice = new Mock<IEventRepository>();
        private Event _event;
        private readonly EventViewModel _eventViewModel;
        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _eventServices = new EventService(eventservice.Object);

            _output = output;

            _event = new Event
            {
                Id = 1,
                Name = "Event1",
                Description = "Description1",
                Status = "Status1"
            };


            _eventViewModel = new EventViewModel
            {
                Id = 1,
                Name = "Event1",
                Description = "Description1",
                Status = "Status1"
            };

        }

        /// <summary>
        /// Test to validate if event id must be greater then 0 charactor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidEventIdIsPassed()
        {
            //Arrange
            bool res = false;
            var politicalPartyId = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                eventservice.Setup(repo => repo.GetById(politicalPartyId)).ReturnsAsync(_event);
                var result = await _eventServices.GetById(politicalPartyId);
                if (result != null || result.Id > 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}
