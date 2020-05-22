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
        public static XmlService _xmlService;
        public static PlayerService _playerService;
        public static CoachService _coachService;
        public static TeamService _teamService;

        public Program(XmlService xmlService, PlayerService playerService, CoachService coachService, TeamService teamService)
        {
            _xmlService = xmlService;
            _playerService = playerService;
            _coachService = coachService;
            _teamService = teamService;
        }
        private static void Run()
        {

        }

        static void Main(string[] args)
        {
            var p = new Program(new XmlService(), new PlayerService(), new CoachService(), new TeamService());
            XmlDocument doc = _xmlService.GetXml();
            var players = _playerService.GetPlayers(doc);
            var coaches = _coachService.GetCoaches(doc);
            var teams = _teamService.GetTeams(doc);
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
