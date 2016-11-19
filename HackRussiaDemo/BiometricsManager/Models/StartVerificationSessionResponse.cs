using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricsManager.Models
{
    public class StartVerificationSessionResponse
    {
        public string verificationId { get; set; }

        public string password { get; set; }
    }
}
