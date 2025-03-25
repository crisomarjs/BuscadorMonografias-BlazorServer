
using Microsoft.AspNetCore.Components;

namespace BuscadorMonografias.Components.Pages
{
    public partial class Home
    {
        [Inject] private NavigationManager navigationManager { get; set; }

        private void GoToMonografias()
        {
            navigationManager.NavigateTo("/mapasesquemas");
        }

        private void GoToMapasEsquemas()
        {
            navigationManager.NavigateTo("/monografias");
        }

    }
}
