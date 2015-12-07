using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        PaGolokContext dbContext;

        public PaGolokContext Init()
        {
            return dbContext ?? (dbContext = new PaGolokContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
