using System;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class WorkViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int CountyId { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public Guid? DealCustomerId { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public Guid StateId { get; set; }
    }
}
