using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{
    public class UnitOfWork : IDisposable
    {
        private BankContext bankContext = new BankContext();
        private Repository<Owner> ownerRepos;
        private Repository<ClientCheck> checkRepos;
        private bool disposed = false;

        public Repository<Owner> Owners
        {
            get
            {
                if(ownerRepos == null) {
                    ownerRepos = new Repository<Owner>(bankContext);
                }
                return ownerRepos;
            }
        }

        public Repository<ClientCheck> ClientChecks
        {
            get
            {
                if (checkRepos == null)
                {
                    checkRepos = new Repository<ClientCheck>(bankContext);  
                }
                return checkRepos;
            }
        }

        public void Save()
        {
            bankContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    bankContext.Dispose();  
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);  
            GC.SuppressFinalize(this);
        }
    }
}
