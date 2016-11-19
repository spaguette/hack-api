using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Newtonsoft.Json;

using BiometricsManager.Properties;
using BiometricsManager.Models;

namespace BiometricsManager
{
    public class BiometricsLogic
    {
        public StartVerificationSessionResponse startVerification(string personId)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                return JsonConvert.DeserializeObject<StartVerificationSessionResponse>(
                    client.DownloadString(Settings.Default.VoiceKeyHost)
                    );
            }
        }
    }
}
