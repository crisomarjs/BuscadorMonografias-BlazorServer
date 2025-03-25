using BuscadorMonografias.Models;
using BuscadorMonografias.Repository;
using Microsoft.AspNetCore.Components;

namespace BuscadorMonografias.Components.Pages.MapasEsquemas
{
    public partial class ListMapasEsquemas
    {
        [Inject] 
        private IMapasEsquemasRepository MapasEsquemasRepository { get; set; }
        private List<MapaEsquema> listaMapasEsquemas = new List<MapaEsquema>();
        public string _searchString;

        protected override async Task OnInitializedAsync()
        {
            listaMapasEsquemas = await MapasEsquemasRepository.GetMapasEsquemas();
        }

        private async Task OnSearch(string searchString)
        {
            _searchString = searchString;

            if (string.IsNullOrWhiteSpace(searchString))
            {
                listaMapasEsquemas = await MapasEsquemasRepository.GetMapasEsquemas(); // Cargar todos
            }
            else
            {
                listaMapasEsquemas = (await MapasEsquemasRepository.GetMapasEsquemas())
                    .Where(x => x.Nombre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }
}
