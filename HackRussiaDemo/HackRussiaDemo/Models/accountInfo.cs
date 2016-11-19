using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackRussiaDemo.Models
{
    /// <summary>
    /// Информация о счёте
    /// </summary>
    public class accountInfo
    {
        /// <summary>
        /// Идентификатор кошелька
        /// </summary>
        public string walletId { get; set; }

        /// <summary>
        /// Доступный остаток
        /// </summary>
        public double balance { get; set; }
    }
}