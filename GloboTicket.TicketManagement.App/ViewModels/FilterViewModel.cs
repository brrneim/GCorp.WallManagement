using System;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class FilterViewModel
    {
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public Guid SelectedCityId{ get; set; }

        public Guid SelectedCountyId { get; set; }

        public Guid SelectedCategoryId { get; set; }

        public Guid DealCustomerId { get; set;}

    }
}
