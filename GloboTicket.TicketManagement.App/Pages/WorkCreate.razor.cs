using GloboTicket.TicketManagement.App.Auth;
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
using static AutoMapper.Internal.ExpressionFactory;



namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class WorkCreate
    {
        public WorkViewModel WorkViewModel { get; set; }

        [Inject]
        public IWorkDataService WorkDataService { get; set; }
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }
        public WorkCreate()
        {
            //GetCity();
        }

        protected async void GetCity()
        {
            if (WorkViewModel is null)
            {
                WorkViewModel = new WorkViewModel();
            }
            WorkViewModel.CityList = await WorkDataService.GetAllCities();
        }

        protected async void GetCounty()
        {
            if (WorkViewModel is null)
            {
                WorkViewModel = new WorkViewModel();
            }
            if (!string.IsNullOrWhiteSpace(WorkViewModel.CityId))
            {
                int cityId = int.Parse(WorkViewModel.CityId);
                WorkViewModel.CountyList = await WorkDataService.GetAllCounties(cityId);
            }

        }

        protected async void CreateWorkButton()
        {
            CreateWorkModel createWork = new CreateWorkModel();
            createWork.Description = WorkViewModel.Description;
            createWork.CustomerId = new Guid("A93D4BEF-C25D-4C45-9F3F-0CD148871BBD");
            createWork.CityId = WorkViewModel.CityList.FirstOrDefault(a => a.CityId == int.Parse(WorkViewModel.CityId)).Id;
            createWork.CountyId = WorkViewModel.CountyList.FirstOrDefault(a => a.CityId == int.Parse(WorkViewModel.CityId)).Id;
            createWork.LocationX = "X";
            createWork.LocationY = "Y";
            createWork.DealCustomerId = null;
            createWork.ExpireDate = WorkViewModel.ExpireDate;
            createWork.IsActive = true;
            createWork.StateId = new Guid("A2573410-D8C7-4FAE-821D-78001D29B4E9");
            var createdWork = await WorkDataService.CreateWorkModel(createWork);
        }

        protected async override Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            if (WorkViewModel is null)
            {
                WorkViewModel = new WorkViewModel();
                WorkViewModel.CityId = "34";
            }
            else
            {
                WorkViewModel.CityId = WorkViewModel.CityId;
            }

            WorkViewModel.CityList = await WorkDataService.GetAllCities();
            if (!string.IsNullOrWhiteSpace(WorkViewModel.CityId))
            {
                int cityId = int.Parse(WorkViewModel.CityId);
                WorkViewModel.CountyList = await WorkDataService.GetAllCounties(cityId);
            }

        }

        protected async void OnCityChanged(ChangeEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(WorkViewModel.CityId))
            {
                int cityId = int.Parse(WorkViewModel.CityId);
                WorkViewModel.CountyList = await WorkDataService.GetAllCounties(cityId);
            }
        }
    }
}
