using Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Order :BaseEntity
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Addresss { get; set; }

    }
}
