using BloodBowl2Luck.Services;
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
        public static PlayerService _playerService;
        public static XmlService _xmlService;

        public Program(XmlService xmlService,PlayerService playerService)
        {
            _xmlService = xmlService;
            _playerService = playerService;
        }
        private static void Run()
        {

        }

        static void Main(string[] args)
        {
            var p = new Program(new XmlService(), new PlayerService());
            XmlDocument doc = _xmlService.GetXml();
            var players = _playerService.GetPlayers(doc);
            var count = 0;
            foreach (XmlNode node in doc.DocumentElement.GetElementsByTagName("Results"))
            {
                count++;
            }
            
            System.Console.WriteLine(count);
            var test = 3;
        }
    }
}
