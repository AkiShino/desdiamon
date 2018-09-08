using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Feature.Account.Infrastructure.Core
{
    public class ApiResponseException : Exception
    {
        private List<string> _messages { get; }

        public ApiResponseException(List<string> messages)
        {
            this._messages = messages;
        }

        public ApiResponseException(string messages)
        {
            this._messages = new List<string> { messages };
        }
        
        public object GetResponseMessage
        {
            get
            {
                if (_messages.Count > 1)
                {
                    return new { messages = _messages };
                }
                else
                {
                    return new { message = _messages.First() };
                }
            }

        }
    }
}