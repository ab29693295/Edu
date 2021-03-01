using System;
using System.Xml;
namespace Edu.Web.Pay
{
    public class SafeXmlDocument:XmlDocument
    {
        public SafeXmlDocument()
        {
            this.XmlResolver = null;
        }
    }
}
