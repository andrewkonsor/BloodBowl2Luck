using BloodBowl2Luck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

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
                                    foreach (XmlElement v in playerDataChildren)
                                    {
                                        if (v.Name == "Ma") tempPlayer.Ma = Convert.ToInt16(v.FirstChild.Value);
                                        else if (v.Name == "Name") tempPlayer.Name = v.FirstChild.Value;
                                        else if (v.Name == "Ag") tempPlayer.Ag = Convert.ToInt16(v.FirstChild.Value);
                                        else if (v.Name == "Level") tempPlayer.Level = Convert.ToInt16(v.FirstChild.Value);
                                        else if (v.Name == "Experience") tempPlayer.Experience = Convert.ToInt16(v.FirstChild.Value);
                                        else if (v.Name =="Number") tempPlayer.Number = Convert.ToInt16(v.FirstChild.Value); 
                                        else if (v.Name == "Av") tempPlayer.Av = Convert.ToInt16(v.FirstChild.Value); 
                                        else if (v.Name == "St") tempPlayer.St = Convert.ToInt16(v.FirstChild.Value); 
                                        else if (v.Name == "Id") tempPlayer.PlayerId = Convert.ToInt16(v.FirstChild.Value);
                                        else if (v.Name == "TeamId") tempPlayer.TeamId = Convert.ToInt16(v.FirstChild.Value);
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
