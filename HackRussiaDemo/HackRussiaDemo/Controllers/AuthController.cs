using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DatabaseManager;
using HackRussiaDemo.Models;

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
                return 
                    String.Join(" ",
                    BiometricsManager.digitsProcessor
                    .digitHumanizer(BiometricsManager.digitsProcessor.getRandomDigits()));
            }
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public bool createUser(createUserRequest req)
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
