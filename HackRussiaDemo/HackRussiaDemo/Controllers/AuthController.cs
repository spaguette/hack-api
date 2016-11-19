using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DatabaseManager;
using BiometricsManager;
using HackRussiaDemo.Models;

namespace HackRussiaDemo.Controllers
{
    /// <summary>
    /// контроллер авторизации
    /// </summary>
    public class AuthController : ApiController
    {
        [HttpPost]
        public string startSession(startSessionRequest req)
        {
            if(!dbLogic.checkIfExists(req.email))
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User not found"}
                    );
            }
            else
            {
                return 
                    String.Join(" ",
                    digitsProcessor
                    .digitHumanizer(digitsProcessor.getRandomDigits()));
            }
        }

        [HttpGet]
        public string startSession(string email)
        {
            if (!dbLogic.checkIfExists(email))
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User not found" }
                    );
            }
            else
            {
                return
                    String.Join(" ",
                    digitsProcessor
                    .digitHumanizer(digitsProcessor.getRandomDigits()));
            }
        }


        public bool createUser(createUserRequest req)
        {
            BiometricsLogic.createPerson(
                req.email,
                req.voiceSamples[0].password,
                req.voiceSamples[0].data
                );


            for (int i = 1; i < 3; i++)
            {
                BiometricsLogic.addVoiceModel(
                    req.email,
                    req.voiceSamples[i].password,
                    req.voiceSamples[i].data
                    );
            }

            dbLogic.insertUser(req.email, req.authToken);

            return true;
        }

        /// <summary>
        /// Верификация пользователя
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <param name="audioSample">Голосовой образец</param>
        /// <returns></returns>
        public double verifyUser(string email, string password, byte[] audioSample)
        {
            return BiometricsLogic.startVerification(email, password, audioSample);
        }
    }
}
