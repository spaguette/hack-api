using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web.Http;

using DatabaseManager;
using BiometricsManager;
using HackRussiaDemo.Models;
using HackRussiaDemo.Properties;

namespace HackRussiaDemo.Controllers
{
    /// <summary>
    /// контроллер авторизации
    /// </summary>
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/Auth/startSession")]
        public HttpResponseMessage startSession(startSessionRequest req)
        {
            if(dbLogic.getUser(req.email) == null)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User not found"}
                    );
            }
            else
            {
                var respMessage = new HttpResponseMessage();
                respMessage.Content = new StringContent(string.Join(" ",
                    digitsProcessor
                    .digitHumanizer(digitsProcessor.getRandomDigits())));

                var cookie = new CookieHeaderValue("sessionHeader", CryptoManager.encodeData(req.email));
                cookie.Expires = DateTimeOffset.Now.AddDays(1/2);
                cookie.Domain = Request.RequestUri.Host;
                cookie.HttpOnly = true;
                cookie.Path = "/";
                respMessage.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                return respMessage;
            }
        }

        /*[HttpPost]
        [Route("api/Auth/createUser")]
        public object createUser(userRequest req)
        {
            req.authToken = "no yandex";

            if(!checkCookie(Request, req.email))
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "User not authorized!" }
                    );
            }

            var modelsToRecord = BiometricsLogic.createPerson(
                req.email,
                req.voiceSamples.password,
                req.voiceSamples.data
                );

            dbLogic.insertUser(req.email, req.authToken, 1);

            return new { ModelsToRecord = modelsToRecord };
        }*/


        [HttpPost]
        [Route("api/Auth/addVoiceModel")]
        public object addVoiceModel(userRequest req)
        {
            /*if (!checkCookie(Request, req.email))
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "User not authorized!" }
                    );
            }*/

            req.authToken = "no yandex";
            req.voiceSample.password = "ноль один два три четыре пять шесть семь восемь девять";

            var usr = dbLogic.getUser(req.email);

            if(usr == null)
            {
                var modelsToRecord = BiometricsLogic.createPerson(
                req.email,
                req.voiceSample.password,
                req.voiceSample.data
                );

            
            for(int i = 1; i < 3; i++)
            {
                BiometricsLogic.addVoiceModel(
                    req.email,
                    req.voiceSamples[i].password,
                    req.voiceSamples[i].data
                    );
            }

            for (int i = 1; i < 3; i++)
            {
                var modelsToRecord = BiometricsLogic.addVoiceModel(
                req.email,
                req.voiceSample.password,
                req.voiceSample.data,
                usr.VoiceModels
                );

                usr.VoiceModels++;

                dbLogic.updateUser(usr.Id, usr);

                return new { ModelsToRecord = modelsToRecord };
            }
        }

        [HttpPost]
        [Route("api/Auth/verifyUser")]
        public double verifyUser(string email, string password, string audioSample)
        {
            if (!checkCookie(Request, email))
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "User not authorized!" }
                    );
            }

            return BiometricsLogic.startVerification(email, password, audioSample);
        }

        public bool checkCookie(HttpRequestMessage req, string email)
        {
            var cookie = req.Headers.GetCookies("sessionHeader").FirstOrDefault();

            if(cookie == null)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "No auth token!" }
                    );
            }

            if(dbLogic.getUser(email).email != CryptoManager.decrypt(cookie["sessionHeader"].Value))
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Incorrect auth token!" }
                    );
            }

            return true;
        }
    }
}
