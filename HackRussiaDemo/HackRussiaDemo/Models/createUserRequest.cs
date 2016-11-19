using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BiometricsManager.Models;

namespace HackRussiaDemo.Models
{
    public class createUserRequest
    {
        public string email { get; set; }

        public string authToken { get; set; }

        public AudioRecord voiceSamples { get; set; }
    }
}