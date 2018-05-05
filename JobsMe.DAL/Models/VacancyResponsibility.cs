namespace JobsMe.DAL.Models
{
    public class VacancyResponsibility
    {
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public Responsibility Responsibility { get; set; }
        public int ResponsibilityId { get; set; }
    }
}
