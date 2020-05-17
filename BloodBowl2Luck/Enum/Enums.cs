using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowl2Luck.Enum
{
    public class Enums
    {
        public enum ActionTypeEnum
        {
            Block = 1,
            Blitz = 2,
            Handoff = 4,
            Foul = 5,
            BlockedDown = 6,
            Negatrait = 15,
            Move_Activate = 42
        }

        public enum RollTypeEnum
        {
            GFI = 1,
            Dodge = 2,
            Armour = 3,
            Injury = 4,
            Block = 5,
            Pickup = 7,
            Catch = 9,
            Scatter = 10,
            Pass = 12,
            Intercept = 16,
            BoneHead = 20,
            ReallyStupid = 21,
            WildAnimal = 22,
            Loner = 23,            
        }

        public enum SkillEnum
        {
            Block = 1,
            Dodge = 2,

        }
    }
}
