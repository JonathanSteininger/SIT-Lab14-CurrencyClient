using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lab14
{
    public static class JSONFactory
    {
        public static string SerialiseObject(object obj) => JsonConvert.SerializeObject(obj);
        public static object DesialiseObject(string json)
        {
            if (string.IsNullOrEmpty(json)) 
                throw new Exception("Json string empty or null");

            JObject temp = JObject.Parse(json);
            string type = (string)temp["Type"];

            if (string.IsNullOrEmpty(type)) 
                throw new Exception($"Json object type property empty or null: type={type}");

            switch(type)
            {
                case nameof(Response):
                    return JsonConvert.DeserializeObject<Response>(json);
                case nameof(Request): 
                    return JsonConvert.DeserializeObject<Request>(json);
                default: throw new Exception("object has no known type");
            }
            
        }
    }
}
