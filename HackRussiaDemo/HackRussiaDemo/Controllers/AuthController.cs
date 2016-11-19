using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HackRussiaDemo.Controllers
{
    /// <summary>
    /// контроллер авторизации
    /// </summary>
    public class AuthController : ApiController
    {
        /// <summary>
        /// Проверка, существует ли пользователь
        /// </summary>
        public bool checkIfExists(string email)
        {
            return false;
        }
    }
}
