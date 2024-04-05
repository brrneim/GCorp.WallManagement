using System;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class CountyListModel
    {
        public Guid Id { get; set; }
        public int CountyId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
