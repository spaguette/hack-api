using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using HackRussiaDemo.Models;

namespace HackRussiaDemo.Controllers
{
    public class HomeController : ApiController
    {
        public accountInfo getAccountInfo()
        {
            return new accountInfo()
            {
                balance = 17.36,
                walletId = "12345wallet"
            };
        }
    }
}
