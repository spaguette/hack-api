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
    public static class BiometricsLogic
    {
        public static bool createPerson(string personId, string password, byte[] audioData)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    var request = JsonConvert.SerializeObject(new CreatePersonRequest()
                    {
                        personId = personId
                    });

                    client.UploadString(
                    Settings.Default.VoiceKeyHost + "person"
                    , "POST", request);

                    var addModelRequest = JsonConvert.SerializeObject(new AudioRecord()
                    {
                        data = audioData,
                        password = password
                    });

                    client.UploadString(
                         String.Format("{0}person/{1}/dynamic/file", Settings.Default.VoiceKeyHost, personId),
                         addModelRequest
                        );

                    return true;
                }
                catch (WebException ex)
                {
                    var response = client.UploadString(
                        String.Format("{0}person/{1}",
                        Settings.Default.VoiceKeyHost, personId),
                        "DELETE", ""
                        );

                    throw ex;
                }
            }
        }

        public static bool addVoiceModel(string personId, string password, byte[] audioData)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";

                    var addModelRequest = Encoding.UTF8.GetBytes(
                        JsonConvert.SerializeObject(new AudioRecord()
                    {
                        data = audioData,
                        password = password
                    }));

                    client.UploadData(
                         String.Format("{0}person/{1}/dynamic/file", Settings.Default.VoiceKeyHost, personId),
                         "PUT",
                         addModelRequest
                        );
                }

                return true;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public static double startVerification(string personId, string password, byte[] audioData)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                var compareRequest = Encoding.UTF8.GetBytes(
                        JsonConvert.SerializeObject(new AudioRecord()
                        {
                            data = audioData,
                            password = password
                        }));

                var response = client.UploadData(
                     string.Format("{0}person/{1}/dynamic/comparison/file", Settings.Default.VoiceKeyHost, personId),
                     "POST",
                     compareRequest
                    );

                return JsonConvert.DeserializeObject<VerificationSessionResponse>(
                    Encoding.UTF8.GetString(response)
                    ).score.value;
            }
        }
    }
}
