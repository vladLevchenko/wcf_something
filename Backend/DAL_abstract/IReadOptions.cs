using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL_abstract
{
    public interface IReadOptions
    {
        int Skip { get; set; }
        int Take { get; set; }       
    }
}
