using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManager.Models
{
    public class accountInfo
    {
        public string account { get; set; }

        public double balance { get; set; }

        public string currency { get; set; }

        public avatar avatar { get; set; }

        public balance_details balance_details { get; set; }

        public cards_linked cards_linked { get; set; }
    }
}
