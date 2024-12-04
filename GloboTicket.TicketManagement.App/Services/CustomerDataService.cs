using AutoMapper;
using AutoMapper.Internal;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Services
{
    public class CustomerDataService : BaseDataService, ICustomerDataService
    {
        private readonly IMapper _mapper;

        public CustomerDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }
        public async Task<PagedCustomerListForFilterModel> GetCustomersWithFilters(CustomerFilterViewModel filterViewModel, int page, int size)
        {
            var works = await _client.GetPagedCustomerListByFilterVmAsync(filterViewModel.SelectedCategoryId, filterViewModel.SelectedCityId, filterViewModel.SelectedCountyId, page, size);
            if (works.Count == 0)
            {
                return new PagedCustomerListForFilterModel();
            }

            var pagedCustomerListForFilterModel = new PagedCustomerListForFilterModel();

            pagedCustomerListForFilterModel.Size = works.Size;
            pagedCustomerListForFilterModel.Count = works.Count;
            pagedCustomerListForFilterModel.Page = works.Page;
            pagedCustomerListForFilterModel.CustomerList = new List<CustomerListViewModel>();

            works.CustomerFilterDto.ForAll(x =>
                        pagedCustomerListForFilterModel
                        .CustomerList
                        .Add(new CustomerListViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Surname = x.Surname,
                            Title = x.Title,
                            CategoryTypeNames = string.Join(", ", x.CategoryTypeNames.Select(y => y.Name)),
                            CompanyName = x.CompanyName,
                            Rating = (int)x.Rating,
                            CommentCount = x.CommentCount,
                        }));


            return pagedCustomerListForFilterModel;
        }

        public async Task<System.Guid> CreateCustomerMessage(CreateCustomerMessageModel createCustomerMessageModel)
        {
            var messageId = await _client.CreateCustomerMessage(createCustomerMessageModel);
            return messageId;
        }
        public async Task<System.Guid> GetCustomerIdByEmail(string mail)
        {
            var customerId = await _client.GetCustomerByEmailAsync(mail);
            return customerId;
        }
    }
}
