﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricsManager.Models
{
    public class AudioRecord
    {
        public string password { get; set; }
        public byte[] audioSample { get; set; }
    }
}
