using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer
{
    interface ISerialize
    {
        void Serialize(TraceResult value);
    }
}
