﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DM = DomainModel;

namespace Parking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IParkingService
    {
        [OperationContract]
        DM.Account GetAccountInfo(Guid accountId);
        [OperationContract]
        IEnumerable<DM.Account> GetAllAccounts();
        [OperationContract]
        IEnumerable<DM.Account> GetAllAccountsSecure();
    }

   
}
