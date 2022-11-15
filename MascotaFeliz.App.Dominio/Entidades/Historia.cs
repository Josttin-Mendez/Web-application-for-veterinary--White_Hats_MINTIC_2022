using System;
using System.Collections.Generic;

namespace MascotaFeliz.App.Dominio
{
    public class Historia
    {
        public int Id{get;set;}
        public DateTime FechaInicial{get;set;}
        public List<VisitaPyP> VisitasPyP {set;get;}
    }
}