using System.Data;
using INV.Infastructure;
using INV.Services.Intertface;
using Microsoft.EntityFrameworkCore.Storage;

namespace INV.Services.Reposetory
{
    public class Transaction: ITransaction

    {
        private IDbContextTransaction _dbContextTransaction;

        public Transaction(ApplicationDbcointext context)
        {
            _dbContextTransaction = context.Database.BeginTransaction();
        }


        public void Commit()
        {
            _dbContextTransaction.Commit();
        }

        public void rollback()
        {
            _dbContextTransaction.Rollback();

        }


        public void Dispose()
        {

            _dbContextTransaction.Dispose();
        }
    }
}
