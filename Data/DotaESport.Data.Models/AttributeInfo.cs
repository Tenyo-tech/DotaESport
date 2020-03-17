namespace DotaESport.Data.Models
{
    using System.Collections.Generic;

    using DotaESport.Data.Common.Models;

    public class AttributeInfo : BaseModel<string>
    {
        public AttributeInfo()
        {
            this.Heroes = new HashSet<Hero>();
        }

        public string MainAttribute { get; set; }

        public double? BaseStrength { get; set; }

        public double? StrengthPerLevel { get; set; }

        public double? BaseAgility { get; set; }

        public double? AgilityPerLevel { get; set; }

        public double? BaseIntelligence { get; set; }

        public double? IntelligencePerLevel { get; set; }

        public ICollection<Hero> Heroes { get; set; }
    }
}
