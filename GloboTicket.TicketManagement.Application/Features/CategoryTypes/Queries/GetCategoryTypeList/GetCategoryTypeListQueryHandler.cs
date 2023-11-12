using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace GloboTicket.TicketManagement.Application.Features.CategoryTypes.Queries.GetCategoryTypeList
{
    public class GetCategoryTypeListQueryHandler : IRequestHandler<GetCategoryTypeListQuery, List<CategoryTypeListVm>>
    {
        private readonly IAsyncRepository<CategoryType> _categoryTypeRepository;
        private readonly IMapper _mapper;

        public GetCategoryTypeListQueryHandler(IMapper mapper, IAsyncRepository<CategoryType> categoryTypeRepository)
        {
            _mapper = mapper;
            _categoryTypeRepository = categoryTypeRepository;
        }

        public async Task<List<CategoryTypeListVm>> Handle(GetCategoryTypeListQuery request, CancellationToken cancellationToken)
        {
            var allCategoryTpes = (await _categoryTypeRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CategoryTypeListVm>>(allCategoryTpes);
        }
    }
}
