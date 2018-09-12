using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Tracer
{
    public class JsonSerializer : ISerialize
    {
        public string JsonResult { get; private set; }

        public void Serialize(TraceResult value)
        {
            JsonResult = JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
}
