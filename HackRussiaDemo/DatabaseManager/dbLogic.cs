using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DatabaseManager
{
    /// <summary>
    /// Класс логики работы с БД
    /// </summary>
    public static class dbLogic
    {
        /// <summary>
        /// Проверить, существует ли пользователь
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <returns></returns>
        public static Users getUser(string email)
        {
            using (var db = new HackRussiaTestDBEntities())
            {
                return db.Users.Where(t => t.email == email).FirstOrDefault();
            }
        }

        public static bool insertUser(string email, string authToken, int voiceModels, string textpassword="")
        {
            using (var db = new HackRussiaTestDBEntities())
            {
                db.Users.Add(new Users()
                {
                    email = email,
                    OAuth = authToken,
                    VoiceModels = voiceModels,
                    textPassword = textpassword
                });

                db.SaveChanges();
            }

            return true;
        }

        public static bool updateUser(int userId, Users user)
        {
            using (var db = new HackRussiaTestDBEntities())
            {
                var usr = db.Users.Single(u => u.Id == userId);

                usr = user;
                usr.Id = userId;

                db.SaveChanges();

                return true;

            }
        }
    }
}
