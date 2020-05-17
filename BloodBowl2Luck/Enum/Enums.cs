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

        public enum BlockDiceEnum
        {
            Skull = 0,
            BothDown = 1,
            Push = 2,
            Stumble = 3,
            Pow = 4,
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
            NumberOfFans = 69,
            Weather = 70,
        }

        public enum SkillEnum
        {
            StripBall = 1,
            //2,
            //3,
            //4,
            //5,
            Catch = 6,
            Dodge = 7,
            Sprint = 8,
            PassBlock = 9,
            FoulAppearence = 10,
            Leap = 11,
            ExtraArms = 12,
            MightyBlow = 13,
            //14,
            Horns = 15,
            TwoHeads = 16,
            StandFirm = 17,
            AlwaysHungery = 18,
            Regeneration = 19,
            //20,
            Accurate = 21,
            BreakTackle = 22,
            SneakyGit = 23,
            //24,
            Chainsaw = 25,
            DaughtLess = 26,
            DirtyPlayer = 27,
            DivingCatch = 28,
            //29,
            Block = 30,
            BoneHead = 31,
            VeryLongLegs = 32,
            DisturbingPresence = 33,
            DivingTackle = 34,
            Fend = 35,
            Frenzy = 36,
            Grab = 37,
            Gaurd = 38,
            HailMarryPass = 39,
            Jugernaut = 40,
            JumpUp = 41,
            //42,
            //43,
            Loner = 44,
            NervesOfSteal = 45,
            NoHands = 46,
            Pass = 47,
            PilingOn = 48,
            PrehensileTail = 49,
            //50,
            ReallyStupid = 51,
            RightStuff= 52,
            SafeThrow = 53,
            SecretWeapon = 54,
            Shadowing = 55,
            SideStep = 56,
            Tackle = 57,
            StrongArm = 58,
            Stunty = 59,
            SureFeet = 60,
            SureHands = 61,
            //62,
            ThickSkull= 63,
            ThrowTeamate = 64,
            //65,
            //66,
            WildAnimal = 67,
            Wrestle = 68,
            Tentacles = 69,
            MultipleBlocks = 70,
            Kick = 71,
            KickOffReturn = 72,
            //73,
            //74,
            Claw = 75,
            BallAndChain = 76,
            Stab = 77,
            //78,
            Stakes = 79,
            Bombardier = 80,
            
            //Missing Skills
            /*
             * Titchy
             * TakeRoot
             * Pro
             * NurglesRot
             * Leader
             * HypnoticGaze
             * FanFavourite
             * DumpOff
             * Decay
             * BloodLust
             * BigHand
             * Animosity
             */
        }
    }
}
