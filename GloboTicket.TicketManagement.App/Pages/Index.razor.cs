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

        public ICollection<WorkListViewModel> Works { get; set; }

        public List<CityListModel> Citys { get; set; }

        public List<CategoryListModel> Categories { get; set; }

        public FilterViewModel FilterViewModel { get; set; }
          = new FilterViewModel() { ToDate = DateTime.Now, FromDate = DateTime.Now.AddDays(4) };

        public int SelectedCityId { get; set; }
        public Guid SelectedCountyId { get; set; }
        public Guid SelectedCategoryId { get; set; }
        
        public DateTime SelectedStartTime { get; set; }

        public List<CountyListModel> Counties { get; set; }

        private string selectedString { get; set; }

        protected async override Task OnInitializedAsync()
        {           
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            Works = await WorkDataService.GetAllWorks();
            Citys = WorkDataService.GetAllCities();
            Categories = await WorkDataService.GetCategories();
            
        }
        protected void CitySelected(ChangeEventArgs e)
        {
            SelectedCityId = Convert.ToInt16(e.Value.ToString());

            Counties = WorkDataService.GetAllCounty(SelectedCityId);
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
           var cityId = WorkDataService.GetAllCities().Where(x=>x.CityId == SelectedCityId).FirstOrDefault().Id;

            FilterViewModel.SelectedCityId = cityId;
            FilterViewModel.SelectedCountyId = SelectedCountyId;
            //ApiResponse<Guid> response;

            //response = await WorkDataService.(EventDetailViewModel);
           
            //HandleResponse(response);

        }

    }
}
