using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IOrderRepository
    {
        int SaveCart(CartViewModel model);
        bool PlaceOrder(TransactionViewModel model);
    }
}
