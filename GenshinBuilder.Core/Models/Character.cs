using System;
using System.Collections.Generic;

namespace GenshinBuilder.Core.Models
{
    public class Character
    {
        public string Name { get; set; }
        public Vision Vision { get; set; }
        public Weapon Weapon { get; set; }
        public string Nation { get; set; }
        public string Affiliation { get; set; }
        public long Rarity { get; set; }
        public string Constellation { get; set; }
        public string Birthday { get; set; }
        public string Description { get; set; }
        // public SkillTalent[] SkillTalents { get; set; }
        // public Constellation[] PassiveTalents { get; set; }
        // public Constellation[] Constellations { get; set; }
        public VisionKey VisionKey { get; set; }
        public WeaponType WeaponType { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string SpecialDish { get; set; }
    }
}