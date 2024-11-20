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

        public List<CategoryTypeListVm> Categories { get; set; }

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
            CreateWorkCategoryModel createWorkCategory = new CreateWorkCategoryModel();
            Guid workId = Guid.NewGuid();
            try
            {
                CreateWorkModel createWork = new CreateWorkModel();

                createWork.Description = WorkViewModel.Description;
                var loginUserId = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetCustomerIdAsync();

                createWork.CustomerId = new Guid(loginUserId); //new Guid("A93D4BEF-C25D-4C45-9F3F-0CD148871BBD");
                createWork.CityId = WorkViewModel.CityList.FirstOrDefault(a => a.CityId == int.Parse(WorkViewModel.CityId)).Id;
                Guid countyId = new Guid(WorkViewModel.CountyId);
                createWork.CountyId = WorkViewModel.CountyList.FirstOrDefault(a => a.Id == countyId).Id;
                createWork.LocationX = "X";
                createWork.LocationY = "Y";
                createWork.DealCustomerId = null;
                createWork.ExpireDate = WorkViewModel.ExpireDate;
                createWork.IsActive = true;
                createWork.StateId = new Guid("A2573410-D8C7-4FAE-821D-78001D29B4E9");
                var createdWorkId = await WorkDataService.CreateWorkModel(createWork);
                createWorkCategory.WorkId = createdWorkId;
                createWorkCategory.CategoryTypeId = new Guid(WorkViewModel.CategoryId);
                var workCategory = await WorkDataService.CreateWorkCategoryModel(createWorkCategory);

                NavigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {

            }
        }

        protected async override Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
            Categories = await WorkDataService.GetCategories();

            if (WorkViewModel is null)
            {
                WorkViewModel = new WorkViewModel();
                WorkViewModel.CityId = "34";
                WorkViewModel.ExpireDate = DateTime.Now;
            }
            else
            {
                WorkViewModel.CityId = WorkViewModel.CityId;
                WorkViewModel.ExpireDate = DateTime.Now;
            }

            WorkViewModel.CityList = await WorkDataService.GetAllCities();
            WorkViewModel.ExpireDate = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(WorkViewModel.CityId))
            {
                int cityId = int.Parse(WorkViewModel.CityId);
                WorkViewModel.CountyList = await WorkDataService.GetAllCounties(cityId);
            }

        }

        protected async void OnCityChanged(ChangeEventArgs args)
        {
            int cityId = int.Parse(args.Value.ToString());
            WorkViewModel.CityId = cityId.ToString();

            if (!string.IsNullOrWhiteSpace(WorkViewModel.CityId))
            {
                WorkViewModel.CountyList = await WorkDataService.GetAllCounties(cityId);
                StateHasChanged();
            }
        }
    }
}
