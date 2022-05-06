﻿using System.Net;

namespace UnknownStore.Common.CQRS
{
    public record ResponseBase
    {
        public ResponseBase()
        {
        }

        public ResponseBase(string errorMessage, HttpStatusCode statusCode)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
        public string ErrorMessage { get; init; }
    }
}