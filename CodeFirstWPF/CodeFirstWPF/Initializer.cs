using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstWPF
{
    class Initializer: DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);
        }
    }
}
