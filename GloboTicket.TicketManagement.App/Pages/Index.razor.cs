using GloboTicket.TicketManagement.App.Auth;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class Index
    {
        [Inject]
        public IWorkDataService WorkDataService { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        public ICollection<WorkListViewModel> Works { get; set; }

        protected async override Task OnInitializedAsync()
        {           
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            Works = await WorkDataService.GetAllWorks();

        }

        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("login");
        }

        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("register");
        }

        protected async void Logout()
        {
            await AuthenticationService.Logout();
        }

        protected void NavigateToWorkCreate()
        {
            NavigationManager.NavigateTo("work-create");
        }
        protected void NavigateToMyScreen()
        {
            NavigationManager.NavigateTo("myscreen-create");
        }
        
    }
}
