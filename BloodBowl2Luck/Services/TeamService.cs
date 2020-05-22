using BloodBowl2Luck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using static BloodBowl2Luck.Enum.Enums;

namespace BloodBowl2Luck.Services
{
    public class TeamService
    {
        //Return team by Id
        public TeamModel GetTeamById(int id, List<TeamModel> teams)
        {
            throw new NotImplementedException();
        }
        //Return list of teams for the match
        public List<TeamModel> GetTeams(XmlDocument doc)
        {
            var rtn = new List<TeamModel>();
            var listTeams = doc.GetElementsByTagName("ListTeams")[0];
            foreach (XmlElement team in listTeams)
            {
                var teamState = team.ChildNodes;
                for (int i = 0; i < teamState.Count; i++)
                {
                    if (teamState[i].Name == "Data")
                    {
                        var listCurrentTeams = teamState[i];
                        var tempTeams = new TeamModel();
                        foreach (XmlElement t in listCurrentTeams.ChildNodes)
                        {
                            if (t.Name == "Value") tempTeams.Value = Convert.ToInt16(t.FirstChild.Value);
                            else if (t.Name == "Name") tempTeams.Name = t.FirstChild.Value;
                            else if (t.Name == "IdRace") tempTeams.IdRace = Convert.ToInt16(t.FirstChild.Value);
                        }
                        rtn.Add(tempTeams);

                    }
                }
            }
            return rtn;
        }
    }
}
