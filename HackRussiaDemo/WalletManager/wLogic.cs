using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

using WalletManager.Properties;
using WalletManager.Models;

namespace WalletManager
{
    public static class wLogic
    {
        public static string staticGetAccountInfo(string authToken)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                client.Headers[HttpRequestHeader.Authorization] = string.Format("Bearer {0}", authToken);

                var response = client.UploadData(
                    String.Format("{0}account-info", Settings.Default.walletHost),
                    "POST", Encoding.UTF8.GetBytes("")
                    );

                return response;
            }
        }
    }
}
