using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBowl2Luck.Enum;
using static BloodBowl2Luck.Enum.Enums;

namespace BloodBowl2Luck.Models
{

    public class PlayerModel
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Ma { get; set; }
        public int Ag { get; set; }
        public int Av { get; set; }
        public int St { get; set; }
        public int Level { get; set; }
        public int Number { get; set; }
        public int Experience { get; set; }
        public List<SkillEnum> Skills { get; set; }
        public int TeamId { get; set; }

    }
}
