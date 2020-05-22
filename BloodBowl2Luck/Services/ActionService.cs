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
    public class ActionService
    {


        //Return entire list of actions for the match
        public void GetActions(XmlDocument doc, PlayerService _playerService, List<Models.PlayerModel> players)
        {
            //Big Mess/Work in Progress!
            foreach (XmlNode node in doc.DocumentElement.GetElementsByTagName("ReplayStep"))
            {
                string turn = "";
                string teamName = "";
                string playerName = "";
                string action = "";
                string roll = "";
                var matchInfo = node.ChildNodes;

                foreach (XmlElement block in matchInfo)
                {
                    if (block.Name.Contains("RulesEventBoardAction"))
                    {
                        var matchInfo1 = block.ChildNodes;
                        bool getCellMovement = false;
                        foreach (XmlElement block1 in matchInfo1)
                        {
                            if (block1.Name == "PlayerId")
                            {
                                playerName = block1.FirstChild.Value.ToString();
                                System.Console.WriteLine(_playerService.GetPlayerById(Convert.ToInt32(playerName), players).Name); //The player doing the action

                            }
                            else if (block1.Name == "ActionType" && block1.FirstChild.Value.ToString() == "42") //42 is player activation
                            {
                                getCellMovement = true;
                            }

                            else if (block1.Name == "ActionType" && block1.FirstChild.Value.ToString() == "6") //6 is Armor Break Roll
                            {
                                System.Console.WriteLine("Armor Break Roll");
                                System.Console.WriteLine();
                            }
                            bool hasAT = false;
                            for (int i = 0; i < matchInfo1.Count; i++) //Check if the field ActionType exists, if not it is a movement action
                            {
                                if (matchInfo1[i].Name == "ActionType")
                                {
                                    hasAT = true;
                                }
                            }

                            if (block1.Name.Contains("Order") && (getCellMovement || !hasAT)) //if it is an activation or a movement, then get the X,Y coordinates
                            {
                                var matchInfo2 = block1.ChildNodes;
                                string from = "";
                                string to = "";
                                foreach (XmlElement block2 in matchInfo2)
                                {

                                    if (block2.Name.Contains("CellFrom"))
                                    {
                                        var matchInfo3 = block2.ChildNodes;
                                        string x = "";
                                        string y = "";
                                        foreach (XmlElement block3 in matchInfo3)
                                        {
                                            if (block3.Name.Contains("x"))
                                            {
                                                x = block3.FirstChild.Value.ToString();
                                            }
                                            else if (block3.Name.Contains("y"))
                                            {
                                                y = block3.FirstChild.Value.ToString();
                                            }
                                        }
                                        from = "(" + x + "," + y + ")";
                                    }
                                    else if (block2.Name.Contains("CellTo"))
                                    {
                                        var matchInfo3 = block2.ChildNodes;
                                        foreach (XmlElement block3 in matchInfo3)
                                        {
                                            if (block3.Name.Contains("Cell"))
                                            {
                                                var matchInfo4 = block3.ChildNodes;
                                                string x = "";
                                                string y = "";
                                                foreach (XmlElement block4 in matchInfo4)
                                                {
                                                    if (block4.Name.Contains("x"))
                                                    {
                                                        x = block4.FirstChild.Value.ToString();
                                                    }
                                                    else if (block4.Name.Contains("y"))
                                                    {
                                                        y = block4.FirstChild.Value.ToString();
                                                    }
                                                }
                                                to = "(" + x + "," + y + ")";
                                            }
                                        }
                                    }
                                }
                                if (from.Length > 0)
                                {
                                    if (from == to)
                                    {
                                        System.Console.WriteLine("Activated at " + from);
                                        System.Console.WriteLine("");

                                    }
                                    else
                                    {
                                        if (action == "")
                                        {
                                            System.Console.WriteLine("Moved from " + from + " to " + to);
                                            System.Console.WriteLine("");
                                        }
                                    }

                                }

                            }
                            else if (block1.Name.Contains("Results"))
                            {
                                var matchInfo2 = block1.ChildNodes;
                                foreach (XmlElement block2 in matchInfo2)
                                {
                                    if (block1.Name.Contains("Result"))
                                    {
                                        var matchInfo3 = block2.ChildNodes;
                                        foreach (XmlElement block3 in matchInfo3)
                                        {
                                            if (block3.Name == "RollType")
                                            {
                                                if (block3.FirstChild.Value.ToString() == "5")
                                                {
                                                    System.Console.WriteLine("Block: " + block3.FirstChild.Value.ToString());
                                                    System.Console.WriteLine("");
                                                }
                                                else if (block3.FirstChild.Value.ToString() == "14")
                                                {
                                                    System.Console.WriteLine("Follows Up: " + block3.FirstChild.Value.ToString());
                                                    System.Console.WriteLine("");
                                                }
                                                else if (block3.FirstChild.Value.ToString() == "13")
                                                {
                                                    System.Console.WriteLine("Pushes: " + block3.FirstChild.Value.ToString());
                                                    System.Console.WriteLine("");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //Return entire list of block actions from the match
        public List<string> GetBlockActions(XmlDocument doc, PlayerService _playerService, List<Models.PlayerModel> players)
        {
            bool hasBlocked = false;
            List<string> blocksList = new List<string>();
            foreach (XmlNode node in doc.DocumentElement.GetElementsByTagName("ReplayStep"))
            {
                string turn = "";
                string teamName = "";
                string playerName = "";
                string action = "";
                string roll = "";
                bool rollStatus = false;
                string blockX = "";
                string blockY = "";

                bool hasRerolled = false;
                var matchInfo = node.ChildNodes;
                foreach (XmlElement block in matchInfo)
                {
                    if (block.Name.Contains("RulesEventBoardAction"))
                    {
                        var matchInfo1 = block.ChildNodes;
                        bool getCellMovement = false;

                        foreach (XmlElement block1 in matchInfo1)
                        {

                            if (block1.Name == "PlayerId")
                            {
                                playerName = block1.FirstChild.Value.ToString();
                            }
                            if (block1.Name.Contains("Order"))
                            {
                                var matchInfo2 = block1.ChildNodes;
                                string from = "";
                                string to = "";
                                foreach (XmlElement block2 in matchInfo2)
                                {

                                    if (block2.Name.Contains("CellFrom"))
                                    {
                                        var matchInfo3 = block2.ChildNodes;
                                        string x = "";
                                        string y = "";
                                        foreach (XmlElement block3 in matchInfo3)
                                        {
                                            if (block3.Name.Contains("x"))
                                            {
                                                x = block3.FirstChild.Value.ToString();
                                            }
                                            else if (block3.Name.Contains("y"))
                                            {
                                                y = block3.FirstChild.Value.ToString();
                                            }
                                        }
                                        from = "(" + x + "," + y + ")";
                                    }
                                    else if (block2.Name.Contains("CellTo"))
                                    {
                                        var matchInfo3 = block2.ChildNodes;
                                        foreach (XmlElement block3 in matchInfo3)
                                        {
                                            if (block3.Name.Contains("Cell"))
                                            {
                                                var matchInfo4 = block3.ChildNodes;
                                                string x = "";
                                                string y = "";
                                                foreach (XmlElement block4 in matchInfo4)
                                                {
                                                    if (block4.Name.Contains("x"))
                                                    {
                                                        x = block4.FirstChild.Value.ToString();
                                                    }
                                                    else if (block4.Name.Contains("y"))
                                                    {
                                                        y = block4.FirstChild.Value.ToString();
                                                    }
                                                }
                                                blockX = x;
                                                blockY = y;
                                            }
                                        }
                                    }
                                }
                            }
                            if (block1.Name.Contains("Results"))
                            {
                                var matchInfo2 = block1.ChildNodes;
                                foreach (XmlElement block2 in matchInfo2)
                                {
                                    if (block2.Name.Contains("BoardActionResult"))
                                    {
                                        var matchInfo3 = block2.ChildNodes;
                                        rollStatus = false;
                                        foreach (XmlElement block3 in matchInfo3)
                                        {
                                            if (block3.Name == "RollType")
                                            {
                                                if (block3.FirstChild.Value.ToString() == "5")
                                                {
                                                    playerName = _playerService.GetPlayerById(Convert.ToInt32(playerName), players).Name;
                                                    //blocksList.Add(_playerService.GetPlayerById(Convert.ToInt32(playerName), players).Name + " |" + "Block: " + block3.FirstChild.Value.ToString());
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }

                                            if (block3.Name == "RollStatus")
                                            {
                                                rollStatus = true;
                                            }
                                            if (block3.Name == "RequestType")
                                            {
                                                roll = block3.FirstChild.Value.ToString();
                                            }
                                            if (block3.Name == "CoachChoices")
                                            {
                                                var matchInfo4 = block3.ChildNodes;
                                                string concerned = "";
                                                foreach (XmlElement block4 in matchInfo4)
                                                {

                                                    if (block4.Name == "ConcernedTeam")
                                                    {
                                                        concerned = block4.FirstChild.Value.ToString();
                                                    }
                                                    if (block4.Name == "ListDices")
                                                    {

                                                        string dice = "";
                                                        string[] splitDice = block4.FirstChild.Value.ToString().Split(',');
                                                        int length = splitDice.Length / 2;
                                                        for (int i = 0; i < length; i++)
                                                        {
                                                            if (i + 1 != length)
                                                            {
                                                                dice += splitDice[i] + ",";
                                                            }
                                                            else
                                                            {
                                                                dice += splitDice[i] + ")";
                                                            }
                                                        }

                                                        if (!hasBlocked)
                                                        {
                                                            blocksList.Add(playerName + " Blocks: " + dice + " (" + blockX + "," + blockY + ")");
                                                            hasBlocked = true;
                                                        }
                                                        else if (hasBlocked && roll != "")
                                                        {
                                                            blocksList.Add(playerName + " Rerolls " + dice);
                                                        }
                                                        else if (hasBlocked && roll == "")
                                                        {
                                                            blocksList.Add(playerName + " Chooses " + dice);
                                                            hasBlocked = false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return blocksList;
        }
    }
}

