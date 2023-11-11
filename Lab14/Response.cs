using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    public class Response : DTO
    {
        public double Rate { get; set; }
        public ResponseStatus Status { get; set; }

        public Response() 
        {
            Type = nameof(Response);
        }
        public Response(double rate, ResponseStatus status) : this()
        {
            Rate = rate;
            Status = status;
        }
        public override string ToString() => Rate.ToString();
    }
}
