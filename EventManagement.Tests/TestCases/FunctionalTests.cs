using EventManagaement.Tests.TestCases;
using EventManagement.BusinessLayer.Interfaces;
using EventManagement.BusinessLayer.Services;
using EventManagement.BusinessLayer.Services.Repository;
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

namespace PoliticalParties.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IEventServices _eventServices;
        public readonly Mock<IEventRepository> eventservice = new Mock<IEventRepository>();
        private Event _event;
        private readonly EventViewModel _eventViewModel;
        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
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
        /// Test to register new Event
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Create_Event()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                eventservice.Setup(repos => repos.Create(_event)).ReturnsAsync(_event);
                var result = await _eventServices.Create(_event);
                //Assertion
                if (result != null)
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

        /// <summary>
        /// Using the below test method Update Event by using Event Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Event()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            long id = 1;
            var _updateEvent = new EventViewModel()
            {
                Id = 1,
                Name = "evenet2",
                Description = "Desc",
                Status="Status1"
            };
            //Act
            try
            {
                eventservice.Setup(repos => repos.Update(id,_updateEvent)).ReturnsAsync(_event);
                var result = await _eventServices.Update(id,_updateEvent);
                if (result != null)
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


        /// <summary>
        /// Test to list all Events
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Events()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                eventservice.Setup(repos => repos.GetAll());
                var result = await _eventServices.GetAll();
                //Assertion
                if (result != null)
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

        /// <summary>
        /// Test to find Event by Event Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindEventById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                eventservice.Setup(repos => repos.GetById(id)).ReturnsAsync(_event); ;
                var result = await _eventServices.GetById(id);
                //Assertion
                if (result != null)
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

        /// <summary>
        /// Test to find Event by Event Name
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindEventByName()
        {
            //Arrange
            var res = false;
            string name = "event1";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                eventservice.Setup(repos => repos.GetByName(name));
                var result = await _eventServices.GetByName(name);
                //Assertion
                if (result != null)
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

        /// <summary>
        /// Test to find Event by Event Status
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindEventByStatus()
        {
            //Arrange
            var res = false;
            string statusName = "status1";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                eventservice.Setup(repos => repos.GetByStatus(statusName));
                var result = await _eventServices.GetByStatus(statusName);
                //Assertion
                if (result != null)
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


