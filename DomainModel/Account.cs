using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public List<DomainModel.Car> Cars { get; set; }
    }
}
