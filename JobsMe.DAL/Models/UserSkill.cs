namespace JobsMe.DAL.Models
{
    public class UserSkill
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Skill Skill { get; set; }
        public int SkillId { get; set; }
    }
}
