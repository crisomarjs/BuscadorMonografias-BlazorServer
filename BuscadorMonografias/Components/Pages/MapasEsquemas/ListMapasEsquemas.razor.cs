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
        private bool _readOnly;
        private bool _isCellEditMode;
        private List<string> _events = new();
        private bool _editTriggerRowClick;
        [Inject]
        NavigationManager navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaMapasEsquemas = await MapasEsquemasRepository.GetMapasEsquemas();
        }

        private async Task OnSearch(string searchString)
        {
            _searchString = searchString;

            if (string.IsNullOrWhiteSpace(searchString))
            {
                listaMapasEsquemas = await MapasEsquemasRepository.GetMapasEsquemas();
            }
            else
            {
                listaMapasEsquemas = (await MapasEsquemasRepository.GetMapasEsquemas())
                    .Where(x => x.Nombre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        void StartedEditingItem(MapaEsquema item)
        {
            _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }

        void CanceledEditingItem(MapaEsquema item)
        {
            _events.Insert(0, $"Event = CanceledEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }

        private async Task CommittedItemChanges(MapaEsquema item)
        {
            if (item == null || item.Id == 0)
            {
                _events.Insert(0, "Error: No se pudo actualizar, el elemento no tiene un ID válido.");
                return;
            }

            try
            {
                await MapasEsquemasRepository.UpdateMapasEsquema(item.Id, item);
                _events.Insert(0, $"Evento = CommittedItemChanges, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
                navigationManager.NavigateTo("/mapasesquemas", forceLoad: true);
            }
            catch (Exception ex)
            {
                _events.Insert(0, $"Error al actualizar: {ex.Message}");
            }
        }

    }
}
