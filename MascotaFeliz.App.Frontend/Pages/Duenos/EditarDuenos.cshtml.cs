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
    public class EditarDuenosModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno;
        [BindProperty]
        public Dueno dueno {get;set;}

        public EditarDuenosModel()
        {
            this. _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? duenoId)
        {
            if(duenoId.HasValue)
            {
                dueno = _repoDueno.GetDueno(duenoId.Value);
            }
            else
            {
                dueno = new Dueno();
            }
            if (dueno == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if (dueno.Id > 0)
            {
                dueno = _repoDueno.UpdateDueno(dueno);
            }
            else
            {
                _repoDueno.AddDueno(dueno);
            }
            return Page();
        }
        
    }
}
