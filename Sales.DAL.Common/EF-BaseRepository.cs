using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Common
{
    public class EF_BaseRepository<Key, Tentity> : Interfaces.IBaseRepository<Key, Tentity> where Tentity : class
    {
    }
}
