using DotaESport.Data.Common.Models;

namespace DotaESport.Data.Models
{
    public class HeroAbility : BaseModel<string>
    {
        public string Name { get; set; }

        public int ManaCost { get; set; }

        public double Cooldown { get; set; }

        public string ImgURL { get; set; }

        public string VideoURL { get; set; }

        public string HeroId { get; set; }

        public Hero Hero { get; set; }

    }
}
