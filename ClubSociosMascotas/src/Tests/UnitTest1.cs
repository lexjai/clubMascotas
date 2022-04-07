using Xunit;
using System;
using App;
using Modelos;
using Clubdata;
using System.Collections.Generic;

namespace Clubdata
{

    public class FakeRepository : Clubdata.ClubSocioMascotaData<Socio>
    {
        public void Guardar(List<Socio> lista)
        {
            throw new NotImplementedException();
        }

        public List<Socio> Leer()
        {
            throw new NotImplementedException();
        }
    }
}
namespace Club
{
    using Clubdata;
    public class UnitTest1
    {
        [Fact]
        public void AltaSocio_Test()
        {
            Socio nuevo = new Socio
            {
                nombre = "jairo",
                sexo = Sexo.H,
                dni = "54664"
            };
             
             MascotaSocio nuevo2 = new MascotaSocio();
             var cuenta = nuevo2.socios.Count;
             nuevo2.altaSocio(nuevo);
             var cuentaMenos1 = nuevo2.socios.Count;
             Assert.Equal(cuenta+1, cuentaMenos1);
        }
        [Fact]
         public void BajaSocio_Test()
        {
            Socio nuevo = new Socio
            {
                nombre = "jairo",
                sexo = Sexo.H,
                dni = "54664"
            };
             
             MascotaSocio nuevo2 = new MascotaSocio();
             var cuenta = nuevo2.socios.Count;
             nuevo2.bajaSocio(nuevo);
             var cuentaMenos1 = nuevo2.socios.Count;
             Console.Write($"{cuenta }+{cuentaMenos1}");
             Assert.Equal(cuenta, cuentaMenos1);
        }
        public void AltaMascota_Test()
        {
            Mascota nuevo = new Mascota
            {
                nombre = "jairo",
                especie = Especie.Gato,
            };
             
             MascotaSocio nuevo2 = new MascotaSocio();
             var cuenta = nuevo2.socios.Count;
             nuevo2.altaMascota(nuevo);
             var cuentaMenos1 = nuevo2.socios.Count;
             Assert.Equal(cuenta+1, cuentaMenos1);
        }
        [Fact]
         public void BajaMascota_Test()
        {
            Mascota nuevo = new Mascota
            {
                nombre = "gg",
                especie= Especie.Perro,
            };
             
             MascotaSocio nuevo2 = new MascotaSocio();
             var cuenta = nuevo2.socios.Count;
             nuevo2.bajaMascota(nuevo);
             var cuentaMenos1 = nuevo2.socios.Count;
             Console.Write($"{cuenta }+{cuentaMenos1}");
             Assert.Equal(cuenta, cuentaMenos1);
        }

          [Fact]
         public void ComprarMascota_Test()
        {
            Mascota nuevo = new Mascota
            {
                nombre = "gg",
                especie= Especie.Perro,
            };
             Socio nuevo3 = new Socio
            {
                nombre = "jairo",
                sexo = Sexo.H,
                dni = "54664"
            };
             MascotaSocio nuevo2 = new MascotaSocio();
             var cuenta = nuevo2.socios.Count;
              nuevo2.altaSocio(nuevo3);
               nuevo2.altaMascota(nuevo);
             nuevo2.comprarMascota(nuevo,nuevo3);
             nuevo2.buscarSocio(nuevo3.dni);
             string socio = nuevo2.buscarSocio(nuevo3.dni).nombre +"";
             string nombreSoci = nuevo3.nombre+"";
             Console.WriteLine(socio);
             Console.WriteLine(nombreSoci);
        //comprobamos que se una bien el socio con la mascota comprada
             Assert.Equal(socio, nombreSoci);
        }

    }
}