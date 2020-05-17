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
        private int PlayerId { get; set; }
        private string Name { get; set; }
        private int Ma { get; set; }
        private int Ag { get; set; }
        private int Av { get; set; }
        private int St { get; set; }
        private int Level { get; set; }
        private int Number { get; set; }
        private int Experience { get; set; }
        private List<SkillEnum> Skills { get; set; }
        private int TeamId { get; set; }
    }
}
