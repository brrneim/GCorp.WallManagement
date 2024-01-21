using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class WorkCreate
    {
        public WorkViewModel WorkViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }
        public WorkCreate()
        {

        }

        protected void CreateWorkButton()
        {
           // Save Work
        }


        protected override void OnInitialized()
        {
            WorkViewModel = new WorkViewModel();
        }
    }
}
