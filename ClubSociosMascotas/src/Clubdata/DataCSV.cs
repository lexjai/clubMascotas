﻿using Modelos;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
namespace Clubdata{
    public class MascotasCSV : ClubSocioMascotaData<Mascota>
    {   
        string _file= "../Mascotas.csv";
        public List<Mascota> Leer(){
            List<Mascota> mascotas = new();
            try
            {
                var datos = File.ReadAllLines(_file).ToList();
                datos.ForEach(fila => {
                    var atributos = fila.Split(",");
                    mascotas.Add(new Mascota
                    {
                        nombre = atributos[0],
                        especie = (Especie)Enum.Parse(typeof(Especie), atributos[1]),
                        fechaM = DateTime.ParseExact(atributos[2], "yyyyMMdd", CultureInfo.InvariantCulture),
                        dniSocio = atributos[3],
                    }
                    );
                });

            }
            catch (Exception ex) { 
                
            }
            
            return mascotas;
        }

        public void Guardar(List<Mascota> mascotas){
            List<string> datos = new(){};
            mascotas.ForEach(mascota =>{
                string info = $"{mascota.nombre},{mascota.especie},{mascota.fechaM.ToString("yyyyMMdd")},{mascota.dniSocio}";
                datos.Add(info);
            });
            File.WriteAllLines(_file,datos);
        }
    }
    public class SociosCSV : ClubSocioMascotaData<Socio>{
        string _file = "../Socios.csv"; 
        public List<Socio> Leer(){
            List<Socio> socios = new();
            try
            {
                var datos = File.ReadAllLines(_file).ToList();
            datos.ForEach(fila =>{
                var atributos = fila.Split(",");
                socios.Add(new Socio{
                    nombre = atributos[0],
                    sexo = (Sexo) Enum.Parse(typeof(Sexo),atributos[1]),
                    dni = atributos[2],
                    }
                );
            });
            }
            catch (Exception ex) { 
            
            }
            
            return socios;
        }

        public void Guardar(List<Socio> socios){
            List<string> datos = new(){};
            socios.ForEach(socio =>{
                string info = $"{socio.nombre},{socio.sexo},{socio.dni}";
                datos.Add(info);
            });
            File.WriteAllLines(_file,datos);
        }
    }


}
