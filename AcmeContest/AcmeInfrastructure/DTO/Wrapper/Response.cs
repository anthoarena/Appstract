using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeInfrastructure.DTO.Wrapper {
    /// <summary>
    /// Response object return to all controller request
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> {
        public Response() { }
        public Response(T data) {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}

