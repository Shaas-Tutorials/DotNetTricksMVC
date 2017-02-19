using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TransactionDetails
    {
        public int TransactionDetailsId { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }

        public int UserId { get; set; }
        public int CartId { get; set; }
        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual User User { get; set; }
    }
}
