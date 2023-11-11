using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    public class Request : DTO
    {
        public string Country { get; set; }
        public RequestType ReqType { get; set; }
        public Request()
        {
            Type = nameof(Request);
        }
        public Request(string country, RequestType reqType) : this()
        {
            Country = country;
            ReqType = reqType;
        }
        public override string ToString() => $"{Country}. type: {ReqType.ToString()}";
    }
}
