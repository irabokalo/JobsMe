using System.Collections.Generic;

namespace JobsMe.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
