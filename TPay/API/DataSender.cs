using Newtonsoft.Json;
using TPay.Helpers.Contracts;
using RestSharp;
using System;
using System.Threading.Tasks;
using TPay.Helpers.Implementations;

namespace TPay.API
{
    /// <summary>
    /// This class allows for sending post request and recivin data mapped to c# obect.
    /// </summary>
    public abstract class DataSender
    {
        // private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private ISerializer _serializer;
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSender" /> class.
        /// </summary>
        public DataSender()
        {
            _serializer = new CustomJsonSerializer();
        }

        /// <summary>
        /// Execute request by sending Json object to specified url. 
        /// </summary>
        /// <typeparam name="T">Type of returning object.</typeparam>
        /// <param name="data">Object contains data for send.</param>
        /// <param name="url">Url when request will be executing.</param>
        /// <returns></returns>
        protected async Task<T> Post<T>(object data, string url)
        {
            T result = default(T);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            var jsonData = _serializer.Serialize(data);

            request.AddParameter("application/json; charset=utf-8", jsonData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = await
            client.ExecuteAsync(request);

            try
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<T>(response.Content);
                }

                //Logger.Info("Posting to: {url}" +
                //    "with data: {data}" +
                //    "end with status: {status}"
                //    , url, jsonData, response.StatusCode);

            }
            catch (Exception ex)
            {
                // Logger.Error(ex.Message, "Error when trying post data.");
            }

            return result;
        }
    }
}
