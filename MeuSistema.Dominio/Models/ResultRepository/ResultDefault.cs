using System.Net;

namespace MySystem.Domain.Models.ResultRepository
{
    public class ResultDefault
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public bool Sucess { get; set; }
        public dynamic Entity { get; set; }
    }
}
