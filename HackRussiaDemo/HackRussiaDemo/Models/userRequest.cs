using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BiometricsManager.Models;

namespace HackRussiaDemo.Models
{
    public class userRequest
    {
        public string email { get; set; }

        public string authToken { get; set; }

        public AudioRecord voiceSample { get; set; }
    }
}