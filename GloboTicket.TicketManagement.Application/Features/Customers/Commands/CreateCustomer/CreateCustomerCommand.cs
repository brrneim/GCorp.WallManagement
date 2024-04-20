using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand: IRequest<CreateCustomerCommandResponse>
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string PictureUrl { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPictureUrl { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountyId { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string TiktokLink { get; set; }
        public string LinkedInLink { get; set; }
    }
}
