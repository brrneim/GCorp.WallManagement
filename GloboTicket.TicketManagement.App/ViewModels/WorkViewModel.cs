using System;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class WorkViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public string CityId { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string CountyId { get; set; }
        public Guid CountyGuidId { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public Guid? DealCustomerId { get; set; }
        public DateTime ExpireDate { get; set; }
        public string ExpireDateString { get; set; }
        public bool IsActive { get; set; }
        public Guid StateId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string WorkMessage { get; set; }
        public ICollection<CityListViewModel> CityList { get; set; }
        public ICollection<CountyListViewModel> CountyList { get; set; }
    }
}
