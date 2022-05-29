using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CreateOrderRequestDto : IDto
    {
        // CustomerName, CustomerEmail, CustomerGSM, List<ProductDetail>. ProductDetail objesi: ProductId,UnitPrice,Amount
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }       
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }

        public virtual List<ProductDetail> ProductDetails { get; set; }

    }
    public class ProductDetail : IDto
    {
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }
    }
}

