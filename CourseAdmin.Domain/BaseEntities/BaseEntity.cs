
using System;

namespace CourseAdmin.Domain.BaseEntities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.CreationDate = DateTime.Now;
            this.Deleted = false;
        }

        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UserMod { get; set; }
        public DateTime? ModifyDate { get; set; }

        public int? UserDeleted  { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool Deleted { get; set; }
    }
}
