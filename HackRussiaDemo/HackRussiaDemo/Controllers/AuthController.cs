using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DatabaseManager;

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
            return dbLogic.checkIfExists(email);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <param name="authToken">Авторизационный токен кошелька</param>
        /// <param name="audioSample">Голосовой образец</param>
        /// <returns></returns>
        public bool createUser(string email, string authToken, byte[] audioSample)
        {
            return true;
        }

        /// <summary>
        /// Верификация пользователя
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <param name="audioSample">Голосовой образец</param>
        /// <returns></returns>
        public bool verifyUser(string email, byte[] audioSample)
        {
            return true;
        }
    }
}
