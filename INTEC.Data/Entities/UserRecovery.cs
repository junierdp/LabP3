using System;
namespace INTEC.Data.Entities
{
    public class UserRecovery: BaseEntity
    {
        public Int32 UserId { get; set; }
        public String Token { get; set; }
        public Boolean Used { get; set; }
        public DateTime? UsedDate { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
