using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricsManager.Models
{
    public class VerificationSessionRequest
    {
        public string personId { get; set; }

        public string password { get; set; }

        public byte[] data { get; set; }
    }
}
