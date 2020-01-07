﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SchedulerJobs.Services.VideoApi.Contracts;

namespace SchedulerJobs.Services
{
    public class VideoApiServiceFake : IVideoApiService
    {
        public Task CloseConference(Guid conferenceId)
        {
            return Task.FromResult(HttpStatusCode.OK);
        }

        public Task<List<ConferenceSummaryResponse>> GetOpenConferencesByScheduledDate(DateTime scheduledDate)
        {
            return Task.FromResult(new List<ConferenceSummaryResponse>
            {
                new ConferenceSummaryResponse
                {
                    Id = Guid.NewGuid()
                }
            });
        }

        public Task RemoveVirtualCourtRoom(Guid hearingRefId)
        {
            return Task.FromResult(HttpStatusCode.OK);
        }
    }
}
