﻿using System;
using System.IO;
using System.Net;
using System.Net.Security;

namespace CreativeCoders.Net.WebRequests {
    public interface IHttpWebRequest {
        ICredentials Credentials { get; set; }

        string Method { get; set; }

        string ContentType { get; set; }

        WebHeaderCollection Headers { get; set; }

        Version ProtocolVersion { get; set; }

        RemoteCertificateValidationCallback ServerCertificateValidationCallback { get; set; }

        Stream GetRequestStream();

        WebResponse GetResponse();

        IWebProxy Proxy { get; set; }

        int Timeout { get; set; }
    }
}