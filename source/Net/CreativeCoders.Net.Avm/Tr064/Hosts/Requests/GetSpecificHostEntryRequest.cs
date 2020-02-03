﻿using CreativeCoders.Net.Soap.Request;

namespace CreativeCoders.Net.Avm.Tr064.Hosts.Requests
{
    [SoapRequest("GetSpecificHostEntry", "urn:dslforum-org:service:Hosts:1")]
    public class GetSpecificHostEntryRequest
    {
        [SoapRequestField("NewMACAddress")]
        public string MacAddress { get; set; }
    }
}