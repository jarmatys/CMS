using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TPay.API
{
    /// <summary>
    /// Cointains method for executing post method.
    /// </summary>
    /// <typeparam name="T1">Returning object type.</typeparam>
    /// <typeparam name="T2">Sending object type.</typeparam>
    public interface IPostable<T1, T2>
    {
        /// <summary>
        /// Allows for posting data.
        /// </summary>
        /// <param name="data">Object to send.</param>
        /// <param name="url">Place where object will be send.</param>
        /// <returns>Response mapped to c# object.</returns>
        Task<T2> Post(T1 data, string url);
    }
}
