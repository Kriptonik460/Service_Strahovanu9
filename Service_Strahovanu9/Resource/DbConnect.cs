using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Strahovanu9.Resource
{
    internal class DbConnect
    {
        public static ServiceEntities1 db { get; } = new ServiceEntities1();
    }

}