﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkListByFilter
{
    public class WorkFilterDto
    {
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public Guid CityId { get; set; }
        public Guid CountyId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid DealCustomerId { get; set; }

        public int Page { get; set; }
        public int Size { get; set; }
    }
}
