using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
   public class ReceiptViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TransactionId { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
    }
}
