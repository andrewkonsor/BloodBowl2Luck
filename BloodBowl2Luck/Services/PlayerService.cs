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
    public class PlayerService
    {
        //Return player by Id
        public PlayerModel GetPlayerById(int id, List<PlayerModel> players)
        {
            throw new NotImplementedException();
        }
        //Return list of players for both teams
        public List<PlayerModel> GetPlayers(XmlDocument doc)
        {
            var rtn = new List<PlayerModel>();
            var listTeams = doc.GetElementsByTagName("ListTeams")[0];
            foreach (XmlElement team in listTeams)//TeamState
            {
                
                var teamState = team.ChildNodes;
                for (int i =0; i < teamState.Count; i++)
                {
                    if (teamState[i].Name == "ListPitchPlayers")
                    {
                        var listPitchPlayers = teamState[i];
                        foreach (XmlElement playerStates in listPitchPlayers.ChildNodes)
                        {
                            var playerStateChildren = playerStates.ChildNodes;
                            foreach(XmlElement players in playerStateChildren)
                            {
                                if (players.Name == "Data")
                                {
                                    var playerDataChildren = players.ChildNodes;
                                    var tempPlayer = new PlayerModel();
                                    foreach (XmlElement p in playerDataChildren)
                                    {
                                        
                                        if (p.Name == "Ma") tempPlayer.Ma = Convert.ToInt16(p.FirstChild.Value);
                                        else if (p.Name == "Name") tempPlayer.Name = p.FirstChild.Value;
                                        else if (p.Name == "Ag") tempPlayer.Ag = Convert.ToInt16(p.FirstChild.Value);
                                        else if (p.Name == "Level") tempPlayer.Level = Convert.ToInt16(p.FirstChild.Value);
                                        else if (p.Name == "Experience") tempPlayer.Experience = Convert.ToInt16(p.FirstChild.Value);
                                        else if (p.Name =="Number") tempPlayer.Number = Convert.ToInt16(p.FirstChild.Value); 
                                        else if (p.Name == "Av") tempPlayer.Av = Convert.ToInt16(p.FirstChild.Value); 
                                        else if (p.Name == "St") tempPlayer.St = Convert.ToInt16(p.FirstChild.Value); 
                                        else if (p.Name == "Id") tempPlayer.PlayerId = Convert.ToInt16(p.FirstChild.Value);
                                        else if (p.Name == "TeamId") tempPlayer.TeamId = Convert.ToInt16(p.FirstChild.Value);
                                        else if (p.Name == "ListSkills") PopulatePlayerSkills(p,tempPlayer);
                                        //TODO add List of Skills
                                    }
                                    rtn.Add(tempPlayer);
                                }
                            }
                        }
                    }
                }
            }
            return rtn;

        }

        private void PopulatePlayerSkills(XmlElement p, PlayerModel player)
        {
            var listSkillsSting =  p.FirstChild.Value;
            var csv = listSkillsSting.TrimEnd(')').TrimStart('(');

            var skillArray = csv.Split(',');
            var ints = Array.ConvertAll(skillArray, s => int.Parse(s));
            player.Skills = ints.ToList();
            //foreach (var skill in skillArray)
            //{
            //    var skillint = Convert.ToInt16(skill);
            //    var skillEnum = SkillEnum.Dodge;
            //    playerSkills.Add(skillint);
            //}
            var lfd = 3;
        }

        //Return list of players for a team
        public List<PlayerModel> GetPlayers(TeamModel team)
        {
            throw new NotImplementedException();
        }

        //Return list of players on the field
        public List<PlayerModel> GetPlayersOnField()
        {
            throw new NotImplementedException();
        }

        //Return List of players on the field for a particualar team
        public List<PlayerModel> GetPlayersonField(TeamModel team)
        {
            throw new NotImplementedException();
        }
    }
}
