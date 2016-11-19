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
        [HttpPost]
        /// <summary>
        /// Проверка, существует ли пользователь
        /// </summary>
        public string startSession(string email)
        {
            if(!dbLogic.checkIfExists(email))
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User not found"}
                    );
            }
            else
            {
                return "authstring";
            }
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <param name="authToken">Авторизационный токен кошелька</param>
        /// <param name="audioSample">Голосовой образец</param>
        /// <returns></returns>
        public bool createUser(string email, string authToken, string password, byte[] audioSample)
        {
            return true;
        }

        /// <summary>
        /// Верификация пользователя
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <param name="audioSample">Голосовой образец</param>
        /// <returns></returns>
        public bool verifyUser(string email, string pasword, byte[] audioSample)
        {
            return true;
        }
    }
}
