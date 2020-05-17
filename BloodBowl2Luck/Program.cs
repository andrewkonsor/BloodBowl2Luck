using BloodBowl2Luck.XMLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BloodBowl2Luck
{
    class Program
    {
        public static XmlService _xmlService;

        public Program(XmlService xmlService)
        {
            _xmlService = xmlService;
        }
        private static void Run()
        {

        }

        static void Main(string[] args)
        {
            var p = new Program(new XmlService());
            XmlDocument doc = _xmlService.GetXml();
            var count = 0;
            var replaySteps = doc.GetElementsByTagName("RollType");
            var r1 = replaySteps[0];
            foreach (XmlNode node in doc.DocumentElement)
            {
                
                if(node.Name == "ReplayStep")
                {
                    
                    count++;
                    if (count == 25)
                    {
                        var x = node.FirstChild;
                        var f = 3;
                    }
                }
            }
            
            System.Console.WriteLine(count);
            var test = 3;
        }
    }
}
