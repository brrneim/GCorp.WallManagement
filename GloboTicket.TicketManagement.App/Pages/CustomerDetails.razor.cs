using GloboTicket.TicketManagement.App.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;
using System;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services;
using GloboTicket.TicketManagement.App.ViewModels;
using System.Collections.Generic;
using GloboTicket.TicketManagement.App.Components;


namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class CustomerDetails
    {
        [Parameter]
        public string Id { get; set; }
        private Guid SelectedCustomerId = Guid.Empty;

        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }


        public ICollection<WorkListViewModel> WorkListViewModel { get; set; }

        public FilterViewModel filterViewModel { get; set; }

        private PaginatedList<WorkListVm> paginatedList
= new PaginatedList<WorkListVm>();

        public ICollection<WorkListVm> Works { get; set; }
        private int? pageNumber = 1;

        public CustomerDetails()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            if (Guid.TryParse(Id, out SelectedCustomerId))
            {
                Guid id = new Guid(Id);
                if (WorkListViewModel is null)
                {
                    WorkListViewModel = new List<WorkListViewModel>();
                }
                try

                { 
                    filterViewModel = new FilterViewModel();
                    filterViewModel.DealCustomerId = new Guid(Id);
                    //var works = await WorkDataService.GetWorksWithFilters(filterViewModel, pageNumber.Value, 5);
                    //if (works != null && works.Count > 0)
                    //{
                    //    paginatedList = new PaginatedList<WorkListVm>(works.WorkFilterDto.ToList(), works.Count, pageNumber.Value, 5);
                    //    Works = paginatedList.Items;
                    //}
                    //else
                    //{
                    //    Works = new List<WorkListVm>();
                    //}
                    

                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
