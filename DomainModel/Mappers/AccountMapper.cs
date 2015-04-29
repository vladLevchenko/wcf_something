using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Mappers
{
    public class AccountMapper
    {
        public static DomainModel.Account FromDataModel(Backend.Account dbAcc)
        {
            var bmAcc = new DomainModel.Account();
            bmAcc.AccountId = dbAcc.AccountId;
            bmAcc.Name = dbAcc.Name;
            bmAcc.Cars = new List<DomainModel.Car>();
            foreach(var dbCar in dbAcc.Car)
                bmAcc.Cars.Add(CarMapper.FromDataModel(dbCar));
            return bmAcc;
        }
    }
}
