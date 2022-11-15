using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        IEnumerable<Historia> GetAllHistorias();
        Historia AddHistoria(Historia historia);
        Historia UpdateHistoria(Historia historia);
        void DeleteHistoria(int idHistoria);
        Historia GetHistoria(int idHistoria);
        
    }
}