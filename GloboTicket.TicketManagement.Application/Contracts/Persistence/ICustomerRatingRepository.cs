using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    interface ICustomerRatingRepository : IAsyncRepository<CustomerRating>
    {
        Task<List<CustomerRating>> GetRatingsByCustomerId(int customerId);
    }    

}
