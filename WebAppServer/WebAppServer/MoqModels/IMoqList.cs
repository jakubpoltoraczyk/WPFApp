using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.MoqModels
{
    public interface IMoqList<T>
    {
        public List<T> GetMoqList();
    }
}
