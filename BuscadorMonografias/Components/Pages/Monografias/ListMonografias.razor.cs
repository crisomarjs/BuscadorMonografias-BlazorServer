using BuscadorMonografias.Models;
using BuscadorMonografias.Repository;
using Microsoft.AspNetCore.Components;

namespace BuscadorMonografias.Components.Pages.Monografias
{
    public partial class ListMonografias
    {
        [Inject]
        private IMonografiaRepository MonografiaRepository { get; set; }
        private List<Monografia> listaMonografias = new List<Monografia>();
        public string _searchString;

        protected override async Task OnInitializedAsync()
        {
            listaMonografias = await MonografiaRepository.GetMonografias();
        }

        private async Task OnSearch(string searchString)
        {
            _searchString = searchString;

            if (string.IsNullOrWhiteSpace(searchString))
            {
                listaMonografias = await MonografiaRepository.GetMonografias(); // Cargar todos
            }
            else
            {
                listaMonografias = (await MonografiaRepository.GetMonografias())
                    .Where(x => x.Nombre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }
}
