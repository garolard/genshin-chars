namespace GenshinBuilder.Core.Models
{
    public class Constellation
    {
        public string Name { get; set; }
        public ConstellationUnlock Unlock { get; set; }
        public string Description { get; set; }
        public long? Level { get; set; }
    }
}