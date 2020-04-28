using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TPay.API
{
    public class Sender<T1, T2> : DataSender, IPostable<T1, T2>
    {
        public async Task<T2> Post(T1 data, string url)
        {
            return await base.Post<T2>(data, url);
        }
    }
}
