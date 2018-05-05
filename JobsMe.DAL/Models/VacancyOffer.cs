namespace JobsMe.DAL.Models
{
    public class VacancyOffer
    {
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public Offer Offer { get; set; }
        public int OfferId { get; set; }
    }
}
