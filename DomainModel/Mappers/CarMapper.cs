using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;


namespace DomainModel.Mappers
{
    public class CarMapper
    {
        public static DomainModel.Car FromDataModel(Backend.Car dbCar)
        {
            var bmCar = new DomainModel.Car();
            bmCar.CarId = dbCar.CarId;
            bmCar.License = dbCar.License;
            bmCar.AccountId = dbCar.AccountId;
            return bmCar;
        }

    }
}
