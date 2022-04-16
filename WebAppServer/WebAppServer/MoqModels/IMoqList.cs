using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.MoqModels
{
    /// <summary>
    /// Interface of moqed database
    /// </summary>
    /// <typeparam name="T">type of table</typeparam>
    public interface IMoqList<T>
    {
        public List<T> GetMoqList();
    }
}
