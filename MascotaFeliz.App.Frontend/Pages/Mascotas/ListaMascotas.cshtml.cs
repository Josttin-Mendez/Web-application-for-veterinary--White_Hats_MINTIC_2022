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
    public class ListaMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        [BindProperty(SupportsGet = true)]

        public IEnumerable<Mascota> listaMascotas {get;set;}
        
        public string FiltroBusqueda {get;set;}

        public ListaMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            
        }

        public void OnGet(string FiltroBusqueda)
        {
            listaMascotas = _repoMascota.GetMascotasPorFiltro(FiltroBusqueda);
                        
        }

    }
}

