using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandResponse: BaseResponse
    {
        public CreateCustomerCommandResponse(): base()
        {

        }

        public CreateCustomerDto Customer { get; set; }
    }
}