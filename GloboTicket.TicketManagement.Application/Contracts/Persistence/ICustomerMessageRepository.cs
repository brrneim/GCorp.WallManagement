using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface ICustomerMessageRepository : IAsyncRepository<CustomerMessage>
    {
        Task<IQueryable<CustomerMessage>> GetMessagesByCustomerId(Guid customerId);
    }

}
