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
    public class AsignarModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario (new Persistencia.AppContext());
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria (new Persistencia.AppContext());
        
        [BindProperty]
        public Mascota mascota {get;set;}
        public Dueno dueno {get;set;}
        public Veterinario veterinario {get;set;}
        public Historia historia {get; set;}

        public IEnumerable<Dueno> listaDuenos{get;set;}
        public IEnumerable<Veterinario> listaVeterinarios{get;set;}

        public AsignarModel()
        {
            this._repoMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext()); 
        }
        public void OnGet(int ? mascotaId)
        {
            listaDuenos = _repoDueno.GetAllDuenos();
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
            

            if(mascotaId.HasValue)
            {
                mascota = _repoMascota.GetMascota(mascotaId.Value);

            }
            else
            {
                mascota = new Mascota();
             
               

            }
            if(mascota == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                Page();
            }

        }

        public IActionResult OnPost(Mascota mascota,int duenoId, int veterinarioId, int historiaId, DateTime fechaCreacion)
        {
            if (ModelState.IsValid)
            {
                dueno = _repoDueno.GetDueno(duenoId);
                veterinario= _repoVeterinario.GetVeterinario(veterinarioId);
                
                if(mascota.Id > 0)
                {
                    mascota.Veterinario = veterinario;
                    mascota.Dueno = dueno;
                    _repoMascota.UpdateMascota(mascota);
                    _repoMascota.AsignarDueno(mascota.Id,duenoId);
                    _repoMascota.AsignarVeterinario(mascota.Id,veterinarioId);
                }
                 else
                {
                    mascota = _repoMascota.AddMascota(mascota);
                    _repoMascota.AsignarDueno(mascota.Id,duenoId);
                    _repoMascota.AsignarVeterinario(mascota.Id,veterinarioId);
                    historia = new Historia();
                    {
                        
                        historia.FechaInicial = new DateTime(DateTime.Now.Ticks);
                    }
               
                    historia =_repoHistoria.AddHistoria(historia);
                    _repoMascota.AsignarHistoria(mascota.Id,historia.Id);
                }

                
            }
           
            return RedirectToPage("./ListaMascotas");
        }
    }
}
