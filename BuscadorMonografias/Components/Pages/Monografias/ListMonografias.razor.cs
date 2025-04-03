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
        private bool _readOnly;
        private bool _isCellEditMode;
        private List<string> _events = new();
        private bool _editTriggerRowClick;
        [Inject]
        NavigationManager navigationManager { get; set; }

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

        void StartedEditingItem(Monografia item)
        {
            _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }

        void CanceledEditingItem(Monografia item)
        {
            _events.Insert(0, $"Event = CanceledEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }

        private async Task CommittedItemChanges(Monografia item)
        {
            if (item == null || item.Id == 0)
            {
                _events.Insert(0, "Error: No se pudo actualizar, el elemento no tiene un ID válido.");
                return;
            }

            try
            {
                await MonografiaRepository.UpdateMonografia(item.Id, item);
                _events.Insert(0, $"Evento = CommittedItemChanges, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
                navigationManager.NavigateTo("/monografias", forceLoad: true);
            }
            catch (Exception ex)
            {
                _events.Insert(0, $"Error al actualizar: {ex.Message}");
            }
        }
    }
}
