namespace GenshinBuilder.Core.Models
{
    public class SkillTalent
    {
        public string Name { get; set; }
        public SkillTalentUnlock Unlock { get; set; }
        public string Description { get; set; }
        public TypeEnum? Type { get; set; }
        public Upgrade[] Upgrades { get; set; }
    }
}