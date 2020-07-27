﻿using FluentAssertions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Timers;
using Moq;
using NUnit.Framework;
using SchedulerJobs.Services;
using SchedulerJobs.Services.BookingApi.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Common;

namespace SchedulerJobs.UnitTests.Functions.AnonymiseHearingsConferencesAndDeleteAadUsersFunction
{
    public class RunAnonymiseHearingsConferencesAndDeleteAadUsersFunctionTests
    {
        private Mock<IVideoApiService> _videoApiServiceMock;
        private Mock<IBookingsApiService> _bookingApiServiceMock;
        private Mock<IUserApiService> _userApiServiceMock;
        private readonly TimerInfo _timerInfo = new TimerInfo(new ScheduleStub(), new ScheduleStatus(), true);

        [SetUp]
        public void Setup()
        {
            _videoApiServiceMock = new Mock<IVideoApiService>();
            _bookingApiServiceMock = new Mock<IBookingsApiService>();
            _userApiServiceMock = new Mock<IUserApiService>();

            var usernames = new UserWithClosedConferencesResponse();
            usernames.Username = new List<string>();
            usernames.Username.Add("username1@email.com");
            usernames.Username.Add("username2@email.com");
            usernames.Username.Add("username3@email.com");

            _bookingApiServiceMock.Setup(x => x.GetUsersWithClosedConferences()).ReturnsAsync(usernames);
        }

        [Test]
        public async Task Timer_should_log_message_all_older_conferences_were_updated()
        {
            var logger = (LoggerFake)TestFactory.CreateLogger(LoggerTypes.List);
            await SchedulerJobs.Functions.AnonymiseHearingsConferencesAndDeleteAadUsersFunction.Run(_timerInfo, logger,
                new AnonymiseHearingsConferencesDataService(_videoApiServiceMock.Object, _bookingApiServiceMock.Object, _userApiServiceMock.Object));
            logger.GetLoggedMessages().Last().Should()
                .StartWith("Data anonymised for hearings, conferences older than 3 months.");
        }
    }
}