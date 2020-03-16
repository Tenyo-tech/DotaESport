namespace DotaESport.Data.Models
{
    using DotaESport.Data.Common.Models;
    using DotaESport.Data.Models.Enums;

    public class Hero : BaseModel<string>
    {
        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public AttackType AttackType { get; set; }

        public string AttributeInfoId { get; set; }

        public AttributeInfo? AttributeInfo { get; set; }
    }
}
