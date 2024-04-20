using System;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class CustomerFilterViewModel
    {
        public Guid SelectedCityId { get; set; }

        public Guid SelectedCountyId { get; set; }

        public Guid SelectedCategoryId { get; set; }
    }
}
