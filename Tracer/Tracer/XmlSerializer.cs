using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Tracer
{
    public class XmlSerializer : ISerialize
    {
        public string XmlResult { get; private set; }

        public void Serialize(TraceResult value)
        {
            var document = new XDocument();
            var root = new XElement("root");

            foreach (var thread in value.ThreadResults)
            {
                var threadElement = new XElement("thread");
                threadElement.Add(new XAttribute("id", thread.Key));
                threadElement.Add(new XAttribute("time", thread.Value.Time));

                foreach (var method in thread.Value.Methods)
                {
                    threadElement.Add(MethodResultToXml(method));
                }

                root.Add(threadElement);
            }

            document.Add(root);
            XmlResult = document.ToString();
        }

        private XElement MethodResultToXml(MethodResult method)
        {
            var res = new XElement("method");
            res.Add(new XAttribute("class", method.Class));
            res.Add(new XAttribute("name", method.Name));
            res.Add(new XAttribute("time", method.Time));

            foreach (var innerMethod in method.Methods)
            {
                res.Add(MethodResultToXml(innerMethod));
            }

            return res;
        }
    }
}
