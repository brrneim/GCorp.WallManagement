using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public partial class Customer : AuditableEntity
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
        public Guid? CityId { get; set; }
        public Guid? CountyId { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string TiktokLink { get; set; }
        public string LinkedInLink { get; set; }
        public bool IsPassive { get; set; }


        public City City { get; set; }
        public County County { get; set; }
        [InverseProperty(nameof(CustomerRating.Customer))]
        public ICollection<CustomerRating> CustomerRatings { get; set; }
        [InverseProperty(nameof(CustomerRating.RatingCustomer))]
        public ICollection<CustomerRating> RatingCustomerRatings { get; set; }

        [InverseProperty(nameof(CustomerComment.Customer))]
        public ICollection<CustomerComment> Comments { get; set; }

        [InverseProperty(nameof(CustomerComment.CommentCustomer))]
        public ICollection<CustomerComment> CustomerComments { get; set; }
        public ICollection<CustomerCategoryType> CustomerCategoryTypes { get; set; }
    }
}
