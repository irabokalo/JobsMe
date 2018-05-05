using System.Collections.Generic;

namespace JobsMe.DAL.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VacancyOffer> VacancyOffers { get; } = new List<VacancyOffer>();
    }
}
