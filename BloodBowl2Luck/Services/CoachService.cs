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
    public class CoachService
    {
        //Return coach by Id
        public CoachService GetCoachById(int id, List<CoachModel> players)
        {
            throw new NotImplementedException();
        }
        //Return list of coaches in the match
        public List<CoachModel> GetCoaches(XmlDocument doc)
        {
            var rtn = new List<CoachModel>();
            var listCoaches = doc.GetElementsByTagName("CoachInfos");

            foreach (XmlElement coach in listCoaches)
            {
                var tempCoach = new CoachModel();
                var coachDataChildren = coach.ChildNodes;
                foreach (XmlElement c in coachDataChildren)
                {
                    if (c.Name == "UserId") tempCoach.UserId = c.FirstChild.Value;
                    else if (c.Name == "Login") tempCoach.Login = c.FirstChild.Value;
                    else if (c.Name == "Slot") tempCoach.Slot = Convert.ToInt16(c.FirstChild.Value);
                }
                rtn.Add(tempCoach);
            }
            return rtn;
        }
    }
}
