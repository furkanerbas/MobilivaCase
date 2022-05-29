using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductDto : IDto
    {
        // Id, Description,Category,Unit,UnitPrice
        public int Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public int UnitPrice { get; set; }
    }
}
