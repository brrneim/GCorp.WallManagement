using GloboTicket.TicketManagement.App.Auth;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using static AutoMapper.Internal.ExpressionFactory;

namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class WorkDetails
    {

        [Parameter]
        public string Id { get; set; }
        private Guid SelectedWOrkId = Guid.Empty;

        [Inject]
        public IWorkDataService WorkDataService { get; set; }

        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public WorkViewModel WorkViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            if (Guid.TryParse(Id, out SelectedWOrkId))
            {
                Guid id = new Guid(Id);
                if (WorkViewModel is null)
                {
                    WorkViewModel = new WorkViewModel();
                }
                try
                {
                    WorkViewModel = await WorkDataService.GetWork(id);
                    WorkViewModel.CityList = await WorkDataService.GetAllCities();
                    var categoryList = await WorkDataService.GetCategories();
                    var workCategoryList = await WorkDataService.GetWorkCategories();
                    var workCategory = workCategoryList.FirstOrDefault(a => a.WorkId == id);
                    if (workCategory != null)
                    {
                        WorkViewModel.CategoryName = categoryList.FirstOrDefault(a => a.Id == workCategory.CategoryTypeId).Name;
                        WorkViewModel.CategoryId = categoryList.FirstOrDefault(a => a.Id == workCategory.CategoryTypeId).Id.ToString();
                    }
                    Guid city = new Guid(WorkViewModel.CityId);
                    Guid county = new Guid(WorkViewModel.CountyId);
                    int cityId = WorkViewModel.CityList.FirstOrDefault(a => a.Id == city).CityId;
                    WorkViewModel.City = WorkViewModel.CityList.FirstOrDefault(a => a.Id == city).Name.Trim();
                    WorkViewModel.CountyList = await WorkDataService.GetAllCounties(cityId);
                    WorkViewModel.County = WorkViewModel.CountyList.FirstOrDefault(a => a.Id == county).Name.Trim();
                    WorkViewModel.ExpireDateString = WorkViewModel.ExpireDate.ToShortDateString();
                    var customerMessages = await WorkDataService.GetCustomerMessages(id);

                    var groupCustomerMessages = customerMessages.GroupBy(a => a.CustomerSenderId);
                    int count = 0;
                    foreach (var group in groupCustomerMessages)
                    {
                        var customerSenderId = group.Key;
                        if (customerSenderId == WorkViewModel.CustomerId)
                        {
                            continue;
                        }
                        count++;
                        List<CustomerMessageListViewModel> filteredCustomerMessages = new List<CustomerMessageListViewModel>();

                        // Group' içindeki mesajları döngüye alarak işleyebilirsiniz.
                        foreach (var customerMessage in group)
                        {
                            filteredCustomerMessages.Add(customerMessage);
                        }
                        string htmlContent = $"<b><span style='color: red;'> Mesaj #{count}:</span></b><br />";
                        WorkViewModel.WorkMessage += $"{htmlContent}";
                        PrepareWorkMessage(customerMessages, filteredCustomerMessages, WorkViewModel);
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }


        private void PrepareWorkMessage(List<CustomerMessageListViewModel> customerMessages, List<CustomerMessageListViewModel> filteredCustomerMessages, WorkViewModel workViewModel)
        {

            if (filteredCustomerMessages.Any())
            {
                var filteredMessage = filteredCustomerMessages.FirstOrDefault();
                var messages = customerMessages.Where(a => a.CustomerSenderId == filteredMessage.CustomerReceiverId && a.CustomerReceiverId == filteredMessage.CustomerSenderId).ToList();
                filteredCustomerMessages.AddRange(messages);
                filteredCustomerMessages = filteredCustomerMessages.OrderBy(a => a.CreatedDate).ToList();
                foreach (var customerMessage in filteredCustomerMessages)
                {
                    if (workViewModel.CustomerId == customerMessage.CustomerReceiverId)
                    {
                        string htmlContent = $"<b><span style='color: green;'>{customerMessage.CustomerSenderId}:</span></b> {customerMessage.Message} <br />";
                        workViewModel.WorkMessage += $"{htmlContent}";
                    }
                    else
                    {
                        string htmlContent = $"<b><span style='color: blue;'>{customerMessage.CustomerSenderId}:</span></b> {customerMessage.Message} <br />";
                        workViewModel.WorkMessage += $"{htmlContent}";
                    }
                }
            }
        }

        protected async void SendMessageButton()
        {
            try
            {
                CreateCustomerMessageModel createCustomerMessageModel = new CreateCustomerMessageModel();
                createCustomerMessageModel.Message = WorkViewModel.NewMessage;
                createCustomerMessageModel.CustomerSenderId = new Guid("A93D4BEF-C25D-4C45-9F3F-0CD148871BBD");
                createCustomerMessageModel.CustomerRecieverId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
                createCustomerMessageModel.WorkId = WorkViewModel.Id;
                createCustomerMessageModel.IsRead = false;

                var createdMessage = await CustomerDataService.CreateCustomerMessage(createCustomerMessageModel);
                NavigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {

            }

        }
    }
}
