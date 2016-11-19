using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManager.Models
{
    public class balance_details
    {
        public double total { get; set; }

        public double available { get; set; }

        public double deposition_pending { get; set; }

        public double blocked { get; set; }

        public double debt { get; set; }

        public double hold { get; set; }
    }
}
