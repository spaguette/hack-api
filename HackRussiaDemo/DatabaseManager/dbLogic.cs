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
        public static bool checkIfExists(string email)
        {
            using (var db = new HackRussiaTestDBEntities())
            {
                return (db.Users.Where(t => t.email == email).Count() > 0);
            }
        }

        public static bool insertUser(string email, string authToken)
        {
            using (var db = new HackRussiaTestDBEntities())
            {
                db.Users.Add(new Users()
                {
                    email = email,
                    OAuth = authToken
                });

                db.SaveChanges();
            }

            return true;
        }
    }
}
