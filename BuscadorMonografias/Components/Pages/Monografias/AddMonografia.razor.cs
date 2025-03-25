using BuscadorMonografias.Models;
using BuscadorMonografias.Repository;
using Microsoft.AspNetCore.Components;

namespace BuscadorMonografias.Components.Pages.Monografias
{
    public partial class AddMonografia
    {
        [Inject]
        private IMonografiaRepository MonografiaRepository { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        private Monografia monografia = new Monografia();
        private bool success;

        private async Task OnAddMonografia()
        {
            var addMonografia = await MonografiaRepository.AddMonografia(monografia);
            navigationManager.NavigateTo("/monografias");
        }
    }
}
