﻿using System;
using NUnit.Framework;
using SchedulerJobs.Common.Configuration;
using SchedulerJobs.Common.Security;

namespace SchedulerJobs.UnitTests
{
    public class AzureTokenProviderTests
    {
        [Test]
        public void Should_get_access_token()
        {
            var azureTokenProvider = new AzureTokenProvider(
                new AzureAdConfiguration
                {
                    Authority = "https://login.bbc.com/",
                    TenantId = "teanantid"
                });

            Assert.Throws<AggregateException>(() =>
            azureTokenProvider.GetClientAccessToken("1234", "1234", "1234"));
        }
    }
}
