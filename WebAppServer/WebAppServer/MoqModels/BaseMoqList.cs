using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.MoqModels
{
    public class BaseMoqList<T> : IMoqList<T>
    {
        protected static List<T> _data;
        public List<T> GetMoqList()
        {
            return _data;
        }

        public void PushToMoqList(T elem)
        {
            _data.Add(elem);
        }
    }
}
