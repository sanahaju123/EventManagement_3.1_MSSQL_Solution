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
    public class BoundaryTest
    {
        private readonly ITestOutputHelper _output;
        private readonly IEventServices _eventServices;
        public readonly Mock<IEventRepository> eventservice = new Mock<IEventRepository>();
        private Event _event;
        private readonly EventViewModel _eventViewModel;
        private static string type = "Boundary";

        public BoundaryTest(ITestOutputHelper output)
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
        /// Test to validate Event Name connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Event_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                eventservice.Setup(repo => repo.Create(_event)).ReturnsAsync(_event);
                var result = await _eventServices.Create(_event);
                var actualLength = _event.Name.ToString().Length;
                if (result.Name.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if Event name must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_EventNameMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                eventservice.Setup(repo => repo.Create(_event)).ReturnsAsync(_event);
                var result = await _eventServices.Create(_event);
                if (result != null && result.Name.Length > 3)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if event description must be less then 200 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_EventDescriptionMax200Character()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                eventservice.Setup(repo => repo.Create(_event)).ReturnsAsync(_event);
                var result = await _eventServices.Create(_event);
                if (result != null && result.Description.Length < 200)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate event description connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Event_Decsription_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                eventservice.Setup(repo => repo.Create(_event)).ReturnsAsync(_event);
                var result = await _eventServices.Create(_event);
                var actualLength = _event.Description.ToString().Length;
                if (result.Description.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if event decsription must be greater then 5 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DescriptionMinFiveCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                eventservice.Setup(repo => repo.Create(_event)).ReturnsAsync(_event);
                var result = await _eventServices.Create(_event);
                if (result != null && result.Description.Length > 5)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if  event name must be less then 20 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_EventNameMaxTwentyCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                eventservice.Setup(repo => repo.Create(_event)).ReturnsAsync(_event);
                var result = await _eventServices.Create(_event);
                if (result != null && result.Name.Length < 20)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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