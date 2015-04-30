using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Security.Principal;
using Backend;

namespace Security
{
    public class IdentityValidator:UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            var factory = new Backend.DAL_implementation.RepositoryFactory();
            var accRepo = factory.GetRepository<Account>();
            var user = accRepo.Get().FirstOrDefault(acc => acc.Name == userName);
            if (user == null)
                throw new FaultException("user not found");
            else
            {
                var isPasswordMatched = ValidationHelper.ValidatePassword(password, new UserPasswordHashed { HashedPassword = user.PasswordHash, PasswordSalt = user.PasswordSalt });
                if (!isPasswordMatched)
                    throw new FaultException("wrong password");

            }
        }
    }
    public class RoleAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            var factory = new Backend.DAL_implementation.RepositoryFactory();
            var accRepo = factory.GetRepository<Account>();
            var identity = operationContext.ServiceSecurityContext.PrimaryIdentity;
            var user = accRepo.Get().FirstOrDefault(acc => acc.Name == identity.Name);
            if (user == null)
            {
                operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = new GenericPrincipal(operationContext.ServiceSecurityContext.PrimaryIdentity,new string[]{"Anonymous"});
                return true;
            }
            var role = user.Role.Symbol;
            operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = new GenericPrincipal(operationContext.ServiceSecurityContext.PrimaryIdentity, new string[] { role });
            return true;
        }

    }
}
