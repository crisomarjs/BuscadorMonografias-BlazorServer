using BuscadorMonografias.Models;
using BuscadorMonografias.Repository;
using Microsoft.AspNetCore.Components;

namespace BuscadorMonografias.Components.Pages.MapasEsquemas
{
    public partial class AddMapasEsquemas
    {
        [Inject]
        private IMapasEsquemasRepository MapasEsquemasRepository { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        private MapaEsquema mapasEsquemas = new MapaEsquema();
        private bool success;

        private async Task OnAddMapasEsquemas()
        {
            var addMapasEsquemas = await MapasEsquemasRepository.AddMapasEsquema(mapasEsquemas);
            navigationManager.NavigateTo("/mapasesquemas");
        }
    }
}
