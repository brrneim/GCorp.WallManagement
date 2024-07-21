using GloboTicket.TicketManagement.App.Services;
using GloboTicket.TicketManagement.App.ViewModels;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface ICustomerDataService
    {
        Task<PagedCustomerListForFilterModel> GetCustomersWithFilters(CustomerFilterViewModel filterViewModel, int page, int size);

        Task<System.Guid> CreateCustomerMessage(CreateCustomerMessageModel createCustomerMessageModel);

    }
}
