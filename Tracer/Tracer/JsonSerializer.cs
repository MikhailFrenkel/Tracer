using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Tracer
{
    public class JsonSerializer : ISerialize
    {
        public string Serialize(TraceResult value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
}
