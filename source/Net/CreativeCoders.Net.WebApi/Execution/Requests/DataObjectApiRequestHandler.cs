﻿using System.Threading.Tasks;
using CreativeCoders.Core.Reflection;
using CreativeCoders.Net.Http;
using CreativeCoders.Net.WebApi.Specification;

namespace CreativeCoders.Net.WebApi.Execution.Requests
{
    public class DataObjectApiRequestHandler : ApiRequestHandlerBase
    {
        public DataObjectApiRequestHandler(IHttpClient httpClient) : base(ApiMethodReturnType.DataObject, httpClient)
        {
        }

        public override object SendRequest(RequestData requestData)
        {
            return this.ExecuteGenericMethod<object>(nameof(RequestAsync),
                new[] { requestData.DataObjectType }, requestData);
        }

        private async Task<T> RequestAsync<T>(RequestData requestData)
        {
            using (var response = await RequestResponseMessageAsync(requestData).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();

                var deserializer = GetResponseDeserializer(requestData);
                return deserializer.Deserialize<T>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
        }
    }
}