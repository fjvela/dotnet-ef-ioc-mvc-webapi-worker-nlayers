using System;
using System.Data.Entity;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;

        public UnitOfWork(DbContext context)
        {
            this.dbContext = context;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }
    }
}