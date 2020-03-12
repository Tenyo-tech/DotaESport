namespace DotaESport.Data.Models
{
    using DotaESport.Data.Common.Models;
    using DotaESport.Data.Models.Enums;

    public class Hero : BaseModel<string>
    {
        public string Name { get; set; }

        public AttackType AttackType { get; set; }

        public AttributeType AttributeType { get; set; }
    }
}
