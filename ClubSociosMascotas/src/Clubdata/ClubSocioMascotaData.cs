using System;
using System.Collections.Generic;
namespace Clubdata{
    public interface ClubSocioMascotaData<T>{
        public List<T> Leer();
        public void Guardar(List<T> lista);
    }
}