using GloboTicket.TicketManagement.App.Auth;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using static AutoMapper.Internal.ExpressionFactory;

namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class WorkDetails
    {

        [Parameter]
        public string Id { get; set; }
        private Guid SelectedWOrkId = Guid.Empty;

        [Inject]
        public IWorkDataService WorkDataService { get; set; }
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public WorkViewModel WorkViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();

            if (Guid.TryParse(Id, out SelectedWOrkId))
            {
                Guid id = new Guid(Id);
                if (WorkViewModel is null)
                {
                    WorkViewModel = new WorkViewModel();
                }
                try
                {
                    WorkViewModel = await WorkDataService.GetWork(id);
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}
