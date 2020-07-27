﻿namespace SchedulerJobs.Common.Configuration
{
    public class HearingServicesConfiguration
    {
        public string VideoApiResourceId { get; set; }
        public string VideoApiUrl { get; set; } = "https://localhost:59390/";
        public string BookingsApiResourceId { get; set; }
        public string BookingsApiUrl { get; set; } = "https://localhost:5300/";
        public string UserApiResourceId { get; set; }
        public string UserApiUrl { get; set; } = "https://localhost:5200/";
    }
}
