using Core.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Financeiro
{
    public class FinanceiroBase
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}
