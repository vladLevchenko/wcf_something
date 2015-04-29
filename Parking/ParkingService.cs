using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Backend;
using DM = DomainModel;
using DAL = Backend.DAL_implementation;


namespace Parking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ParkingService : IParkingService
    {

        public DM.Account GetAccountInfo(Guid accountId)
        {
            var factory = new DAL.RepositoryFactory();
            var accountRepository = factory.GetRepository<Account>();
            var acc = accountRepository.Get(accountId);
            return acc != null ? DM.Mappers.AccountMapper.FromDataModel(acc) : null;
        }


        public IEnumerable<DM.Account> GetAllAccounts()
        {
            var factory = new DAL.RepositoryFactory();
            var accountRepository = factory.GetRepository<Account>();
            var accounts = accountRepository.Get().ToList();
            return accounts.Select(acc => DM.Mappers.AccountMapper.FromDataModel(acc));
        }
    }
}
