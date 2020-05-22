using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BloodBowl2Luck.XMLService
{
    public class XmlService
    {
        public XmlService() { }
        public XmlDocument GetXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Andrew\\Desktop\\bb2test\\test2.xml");
            //doc.Load("C:\\Users\\aricm\\OneDrive\\Desktop\\test1.xml");
            return doc;
        }

        public int test()
        {
            return 2 + 2;
        }

        internal void GEtTest()
        {
        }
    }
}
