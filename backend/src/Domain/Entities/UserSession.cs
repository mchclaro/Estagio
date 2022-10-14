using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserSession
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}