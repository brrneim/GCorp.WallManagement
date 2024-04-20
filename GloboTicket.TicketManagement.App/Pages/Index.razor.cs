using GloboTicket.TicketManagement.App.Auth;
using GloboTicket.TicketManagement.App.Components;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private PaginatedList<WorkListVm> paginatedList
    = new PaginatedList<WorkListVm>();

        public ICollection<WorkListVm> Works { get; set; }

        public List<CityListViewModel> Citys { get; set; }

        public List<CategoryTypeListVm> Categories { get; set; }

        public FilterViewModel FilterViewModel { get; set; }
          = new FilterViewModel() { ToDate = DateTime.Now, FromDate = DateTime.Now.AddDays(4) };

        public int SelectedCityId { get; set; }

       // public int SelectedCountyId { get; set; }

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
            FilterViewModel.FromDate = DateTime.Now.AddDays(-30);
            var works = await WorkDataService.GetWorksWithFilters(FilterViewModel, pageNumber.Value, 5);
            if (works != null && works.Count > 0)
            {
                paginatedList = new PaginatedList<WorkListVm>(works.WorkFilterDto.ToList(), works.Count, pageNumber.Value, 5);
                Works = paginatedList.Items;
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
            if(SelectedCityId != 0)
            {
                var x = await WorkDataService.GetAllCities();
                    //..Where(x => x.CityId == SelectedCityId);
                FilterViewModel.SelectedCityId =x.Where(x => x.CityId == SelectedCityId).FirstOrDefault().Id;
            }
            if(SelectedCountyId != Guid.Empty)
            {
                FilterViewModel.SelectedCountyId = SelectedCountyId;
            }

            var works = await WorkDataService.GetWorksWithFilters(FilterViewModel, pageNumber.Value,5);
            if (works != null && works.Count > 0)
            {
                paginatedList = new PaginatedList<WorkListVm>(works.WorkFilterDto.ToList(), works.Count, pageNumber.Value, 5);
                Works = paginatedList.Items;
            }
            else
            {
                Works = new List<WorkListVm>();
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
