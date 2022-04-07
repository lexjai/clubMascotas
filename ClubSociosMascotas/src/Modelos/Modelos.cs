using System;

namespace Modelos{
    public enum Sexo{
        H,M
    }
    public class Socio {
        public string nombre{get; set;}
        public Sexo sexo{get;set;}
        public string dni{get; set;}

        public override string ToString()
        {
            return $"Nombre: {nombre}, Sexo: {sexo}, DNI: {dni}";
        }
    }
    public enum Especie{
        Gato,Perro,ave,ranas,conejos
    }
    public class Mascota {
        public string nombre{get;set;}
        public Especie especie{get;set;}
        public int Edad{get{
                return new DateTime(DateTime.Now.Subtract(fechaM).Ticks).Year -1;
            }
        }
        public string dniSocio{get;set;}
        public DateTime fechaM{get;set;}
        public override string ToString()
        {
            return $"{nombre}, {especie}, {Edad} años ({dueno.nombre})";
        }
        public Socio dueno{get;set;}
    }
}