using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.DataAccess.Abstract.IBaseRepository;

namespace DataAccess.Abstract
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
    }
}
