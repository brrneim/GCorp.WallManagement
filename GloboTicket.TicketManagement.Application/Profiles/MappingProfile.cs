﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList;
using GloboTicket.TicketManagement.Application.Features.Customers.Commands.CreateCustomer;
using GloboTicket.TicketManagement.Application.Features.Customers.Queries.GetCustomerList;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Application.Features.Messages.Queries.GetCustomerMessageList;
using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;
using GloboTicket.TicketManagement.Application.Features.Ratings.Queries.GetCustomerRatingList;
using GloboTicket.TicketManagement.Application.Features.States.Queries.GetStateQueryList;
using GloboTicket.TicketManagement.Application.Features.Works.Queries.GetWorkList;
using GloboTicket.TicketManagement.Application.Models.Dtos;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<CategoryType, CategoryTypeDto>();
            CreateMap<CategoryType, CategoryTypeListVm>();

            CreateMap<State, StateDto>();
            CreateMap<State, StateListVm>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, CustomerListVm>();
            CreateMap<Customer, CreateCustomerCommand>();
            CreateMap<Customer, CreateCustomerDto>();

            CreateMap<CustomerMessage, CustomerMessagesListVm>();
            CreateMap<CustomerRating, CustomerRatingsListVm>();

            CreateMap<Work, WorkListVm>().ReverseMap();
            CreateMap<Work, WorkListVm>();

        }
    }
}
