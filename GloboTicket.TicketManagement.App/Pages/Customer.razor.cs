using GloboTicket.TicketManagement.App.Auth;
using GloboTicket.TicketManagement.App.Components;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class Customer
    {
        public Customer()
        {

        }

        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Inject]
        public IWorkDataService WorkDataService { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        private PaginatedList<CustomerListViewModel> paginatedList
    = new PaginatedList<CustomerListViewModel>();

        public ICollection<CustomerListViewModel> Customers { get; set; }

        public List<CityListViewModel> Citys { get; set; }

        public List<CategoryTypeListVm> Categories { get; set; }

        public CustomerFilterViewModel CustomerFilterViewModel { get; set; }
          = new CustomerFilterViewModel() {  };

        public int SelectedCityId { get; set; }

        public Guid SelectedCountyId { get; set; }

        public Guid SelectedCategoryId { get; set; }

        public DateTime SelectedStartTime { get; set; }

        public List<CountyListViewModel> Counties { get; set; }

        private string selectedString { get; set; }

        private int? pageNumber = 1;

        protected async override Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();


            //Works = await WorkDataService.GetWorksWithFilters(FilterViewModel, pageNumber.Value, 5); // await WorkDataService.GetAllWorks();
            var customers = await CustomerDataService.GetCustomersWithFilters(CustomerFilterViewModel, pageNumber.Value, 5);
            if (customers != null && customers.Count > 0)
            {
                paginatedList = new PaginatedList<CustomerListViewModel>(customers.CustomerList.ToList(), customers.Count, pageNumber.Value, 5);
                Customers = paginatedList.Items;
                StateHasChanged();
            }
            Citys = await WorkDataService.GetAllCities();
            Categories = await WorkDataService.GetCategories();

        }
        protected async void CitySelected(ChangeEventArgs e)
        {
            SelectedCityId = Convert.ToInt16(e.Value.ToString());

            Counties = await WorkDataService.GetAllCounties(SelectedCityId);
            Console.WriteLine("It is definitely: " + SelectedCityId);
            StateHasChanged();
        }
        //protected async Task CitySelected()
        //{


        //    StateHasChanged();
        //}

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

        protected async Task HandleValidSubmit()
        {
            if (SelectedCityId != 0)
            {
                var x = await WorkDataService.GetAllCities();
                //..Where(x => x.CityId == SelectedCityId);
                CustomerFilterViewModel.SelectedCityId = x.Where(x => x.CityId == SelectedCityId).FirstOrDefault().Id;
            }
            if (SelectedCountyId != Guid.Empty)
            {
                CustomerFilterViewModel.SelectedCountyId = SelectedCountyId;
            }

            var customers = await CustomerDataService.GetCustomersWithFilters(CustomerFilterViewModel, pageNumber.Value, 5);
            if (customers != null && customers.Count > 0)
            {
                paginatedList = new PaginatedList<CustomerListViewModel>(customers.CustomerList.ToList(), customers.Count, pageNumber.Value, 5);
                Customers = paginatedList.Items;
            }
            else
            {
                Customers = new List<CustomerListViewModel>();
            }
            StateHasChanged();


        }
        public async void PageIndexChanged(int newPageNumber)
        {
            if (newPageNumber < 1 || newPageNumber > paginatedList.TotalPages)
            {
                return;
            }
            pageNumber = newPageNumber;
            await HandleValidSubmit();
            StateHasChanged();
        }
    }
}
