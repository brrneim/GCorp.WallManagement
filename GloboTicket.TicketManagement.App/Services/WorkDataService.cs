using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Services
{
    public class WorkDataService : BaseDataService, IWorkDataService
    {

        private readonly IMapper _mapper;

        public WorkDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        //public List<CityListModel> GetAllCities()
        //{
        //    var cityList = new List<CityListModel>();
        //    cityList.Add(new CityListModel() { Id = Guid.NewGuid(), CityId = 1, Name = "Adana" });
        //    cityList.Add(new CityListModel() { Id = Guid.NewGuid(), CityId = 6, Name = "Ankara" });
        //    cityList.Add(new CityListModel() { Id = Guid.NewGuid(), CityId = 24, Name = "Erzincan" });
        //    cityList.Add(new CityListModel() { Id = Guid.NewGuid(), CityId = 25, Name = "Erzurum" });

        //    return cityList.ToList();
        //}


        //public List<CountyListModel> GetAllCounty(int cityId)
        //{
        //    var countyList = new List<CountyListModel>();
        //    countyList.Add(new CountyListModel() { Id = Guid.NewGuid(), CityId = 24, Name = "Üzümlü" });
        //    countyList.Add(new CountyListModel() { Id = Guid.NewGuid(), CityId = 24, Name = "Kemah" });
        //    countyList.Add(new CountyListModel() { Id = Guid.NewGuid(), CityId = 24, Name = "Kemaliye" });
        //    countyList.Add(new CountyListModel() { Id = Guid.NewGuid(), CityId = 24, Name = "Tercan" });
        //    countyList.Add(new CountyListModel() { Id = Guid.NewGuid(), CityId = 25, Name = "Aşkale" });
        //    countyList.Add(new CountyListModel() { Id = Guid.NewGuid(), CityId = 6, Name = "Mamak" });
        //    countyList.Add(new CountyListModel() { Id = Guid.NewGuid(), CityId = 6, Name = "Sincan" });

        //    return countyList.Where(x=>x.CityId == cityId).ToList();

        //}


        public async Task<List<WorkListViewModel>> GetAllWorks()
        {
            var allWorks = await _client.GetAllWorksAsync();
            var mappedEvents = _mapper.Map<ICollection<WorkListViewModel>>(allWorks);
            return mappedEvents.ToList();
        }

        public async Task<WorkViewModel> GetWork(Guid workId)
        {
            var work = await _client.GetWorkAsync(workId);
            var mappedEvent = _mapper.Map<WorkViewModel>(work);
            return mappedEvent;
        }

        public async Task<List<CityListViewModel>> GetAllCities()
        {
            var allWorks = await _client.GetAllCitiesAsync();
            var mappedEvents = _mapper.Map<ICollection<CityListViewModel>>(allWorks);
            return mappedEvents.ToList();
        }

        public async Task<List<CountyListViewModel>> GetAllCounties(int cityId)
        {
            var allWorks = await _client.GetAllCountiesAsync(cityId);
            var mappedEvents = _mapper.Map<ICollection<CountyListViewModel>>(allWorks);
            return mappedEvents.ToList();
        }

        public async Task<System.Guid> CreateWorkModel(CreateWorkModel createWorkModel)
        {
            var workId = await _client.CreateWorkAsync(createWorkModel);
            return workId;
        }


        public async Task<List<CategoryTypeListVm>> GetCategories()
        {
            var categoryList = await _client.GetAllCategoryTypesAsync();
            var mappedEvents = _mapper.Map<ICollection<CategoryTypeListVm>>(categoryList);
            return mappedEvents.ToList();

            //categoryList = await 
            //categoryList.Add(new CategoryListModel() { CategoryId = Guid.NewGuid(), Name = "Outdoor işleri" });
            //categoryList.Add(new CategoryListModel() { CategoryId = Guid.NewGuid(), Name = "Ev işleri" });
            //categoryList.Add(new CategoryListModel() { CategoryId = Guid.NewGuid(), Name = "Tasarım" });
            //categoryList.Add(new CategoryListModel() { CategoryId = Guid.NewGuid(), Name = "Yazılım" });

           // return categoryList;
        }

        public async Task<PagedWorkListByFilterVm> GetWorksWithFilters(FilterViewModel filterViewModel, int page, int size)
        {
                                                                            //DateTime fromDate, DateTime toDate, Guid selectedCategoryId, Guid selectedCityId, Guid selectedCountyId, int? page, int? size
            var works = await _client.GetPagedWorkListByFilterVmAsync(filterViewModel.FromDate, filterViewModel.ToDate, filterViewModel.SelectedCategoryId,filterViewModel.SelectedCityId,filterViewModel.SelectedCountyId, page,size);
            if(works.Count ==0)
            {
                return new PagedWorkListByFilterVm();
            }
            var mappedOrders = _mapper.Map<PagedWorkListByFilterVm>(works);

            return mappedOrders;

        }

        //public async Task<List<WorkListViewModel>> GetWorksWithFilters(FilterViewModel filterViewModel)
        //{
        //    var allWorks = await _client.GetAllWorksAsync()
        //}
    }

}
