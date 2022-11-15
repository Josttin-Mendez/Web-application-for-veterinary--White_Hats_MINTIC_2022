using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetallesVeterinariosModel : PageModel
    {
        private readonly IRepositorioVeterinario _repoVeterinario;

        public Veterinario veterinario { get; set;}

        public DetallesVeterinariosModel()
        {
            this._repoVeterinario = new RepositorioVeterinario( new Persistencia.AppContext());

        }

        public IActionResult OnGet(int veterinarioId)
        {
            veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
            if(veterinario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
