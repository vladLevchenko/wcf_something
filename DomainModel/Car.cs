using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Car
    {
        public Guid CarId { get; set; }
        public string License { get; set; }
        public Guid AccountId { get; set; }
    }
}
