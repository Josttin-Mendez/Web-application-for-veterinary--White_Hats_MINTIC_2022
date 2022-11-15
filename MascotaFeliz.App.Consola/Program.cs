using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());

        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());

        private static IRepositorioVisitaPyP _repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //AddDueno();
            //BuscarDueno(4);
            //BorrarDueno(11);
            //AddVeterinario();
            //BuscarVeterinario(6);
            //BorrarVeterinario(12);
            //AddMascota();
            //BorrarMascota(4);
            //ListarMascotas();
            //BuscarMascota(2);
            //BuscarMascotaPorFiltro("Firulay");
            //AsignarDueno();
            //AsignarVeterinario();
            //AsignarHistoria();
            //AddHistoria();
            //BorrarHistoria(2);
            //ListarHistorias();
            //ActualizarMascota(3);
            //ActualizarVeterinario(8);
            //ActualizarDueno(3);
            //AddVisitaPyP();
        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                //Cedula = "1313",
                Nombres = "El chavo",
                Apellidos = "Del ocho",
                Direccion = "El vecindario",
                Telefono = "3345643210",
                Correo = "elchavo@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Correo);
        }

        private static void BorrarDueno(int idDueno)
        {
            _repoDueno.DeleteDueno(idDueno);             
        }

        private static void ActualizarDueno(int idDueno)
         {
            var duenoEncontrado = _repoDueno.GetDueno(idDueno);
            if(duenoEncontrado != null)
            {
                duenoEncontrado.Nombres = "Pedro";
                duenoEncontrado.Apellidos = "Picapiedra";
                duenoEncontrado.Direccion = "Piedradura";
                duenoEncontrado.Telefono = "0102345678";
                duenoEncontrado.Correo = "pedropicapiedra@gmail.com";
                
            }
            _repoDueno.UpdateDueno(duenoEncontrado);
            Console.WriteLine(duenoEncontrado.Nombres + " " + duenoEncontrado.Apellidos + " " + duenoEncontrado.Direccion + " "+ duenoEncontrado.Telefono + " " + duenoEncontrado.Correo);
            
         }

        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                
                Nombres = "Lola",
                Apellidos = "Mento",
                Direccion = "Cali",
                Telefono = "3367893045",
                TarjetaProfesional = "1234567890"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " "+ veterinario.Telefono + " " + veterinario.TarjetaProfesional);
        }

        private static void BorrarVeterinario(int idVeterinario)
        {
            _repoVeterinario.DeleteVeterinario(idVeterinario);             
        }

        private static void ActualizarVeterinario(int idVeterinario)
         {
            var veterinarioEncontrado = _repoVeterinario.GetVeterinario(idVeterinario);
            if(veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombres = "Blanca";
                veterinarioEncontrado.Apellidos = "Nieves";
                veterinarioEncontrado.Direccion = "Disneylandia";
                veterinarioEncontrado.Telefono = "4975102938";
                veterinarioEncontrado.TarjetaProfesional = "5500213453";
                
            }
            _repoVeterinario.UpdateVeterinario(veterinarioEncontrado);
            Console.WriteLine(veterinarioEncontrado.Nombres + " " + veterinarioEncontrado.Apellidos + " " + veterinarioEncontrado.Direccion + " "+ veterinarioEncontrado.Telefono + " " + veterinarioEncontrado.TarjetaProfesional);
            
         }


        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                
                Nombre = "Sasha",
                Color = "Blaco",
                Especie = "Gato",
                Raza = "Angora",
                
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void BorrarMascota(int idMascota)
        {
            _repoMascota.DeleteMascota(idMascota);             
        }

        private static void ActualizarMascota(int idMascota)
         {
            var mascotaEncontrado = _repoMascota.GetMascota(idMascota);
            if(mascotaEncontrado != null)
            {
                mascotaEncontrado.Nombre = "Michito";
                mascotaEncontrado.Color = "Blanco";
                mascotaEncontrado.Especie = "Gato domestico";
                mascotaEncontrado.Raza = "Bengali";
                
            }
            _repoMascota.UpdateMascota(mascotaEncontrado);
            Console.WriteLine(mascotaEncontrado.Nombre + " " + mascotaEncontrado.Color + " " + mascotaEncontrado.Especie + " " + mascotaEncontrado.Raza);
         }

        private static void ListarMascotas()
        {
            var mascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota m in mascotas)
            {
                Console.WriteLine(m.Nombre + " " + m.Color + " " + m.Especie + " " + m.Raza);
            }
          
        }
        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza);
        }

        private static void BuscarMascotaPorFiltro(string filtro)
        {
            var mascota = _repoMascota.GetMascotasPorFiltro(filtro);
            foreach (Mascota m in mascota)
            {
                Console.WriteLine(m.Nombre + " " + m.Color + " " + m.Especie + " " + m.Raza);
            }
        }

        private static void AsignarDueno()
        {
            var dueno = _repoMascota.AsignarDueno(1,2);
            Console.WriteLine(dueno.Nombres+""+dueno.Apellidos);
        }

        private static void AsignarVeterinario()
        {
            var veterinario = _repoMascota.AsignarVeterinario(1,4);
            Console.WriteLine(veterinario.Nombres+" "+veterinario.Apellidos);
        }

        private static void AsignarHistoria()
        {
            var historia = _repoMascota.AsignarHistoria(1,1);
            Console.WriteLine(historia.FechaInicial);
        }

        private static void AddHistoria()
        {

            var historia = new Historia
            {
                
                FechaInicial = new DateTime(2022,09,12)
            };
            _repoHistoria.AddHistoria(historia);
            
        }

        private static void BorrarHistoria(int idHistoria)
        {
            _repoHistoria.DeleteHistoria(idHistoria);             
        }

        private static void ListarHistorias()
        {
            var historias = _repoHistoria.GetAllHistorias();
            foreach (Historia h in historias)
            {
                Console.WriteLine(h.FechaInicial);
            }
          
        }

        private static void AddVisitaPyP()
        {
            var visitaPyP = new VisitaPyP
            {
                FechaVisita = new DateTime(2022,09,13),
                Temperatura = 37.2F,
                Peso = 65.3F,
                FrecuenciaRespiratoria = 43.2F,
                FrecuenciaCardiaca = 10.5F,
                EstadoAnimo = "Alegre",
                Recomendaciones = "Reposo",

            };
            _repoVisitaPyP.AddVisitaPyP(visitaPyP);
        }


    }
}
