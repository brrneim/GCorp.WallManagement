using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public Guid Id { get; set; }
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
        public int? CityId { get; set; }
        public int? CountyId { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string TiktokLink { get; set; }
        public string LinkedInLink { get; set; }
    }
}
