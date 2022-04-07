using App;
using Modelos;

namespace Consola
{
    public class Controlador
    {

        public MascotaSocio MascotaSocioGestor;

        public Vista vista = new Vista();
        public Dictionary<string, Action> opciones;
        public Controlador(MascotaSocio MascotaSocioGestor)
        {
            this.MascotaSocioGestor = MascotaSocioGestor;

            opciones = new Dictionary<string, Action>(){
            {"Listado de mascotas ordenadas por especie",ListaMascotasEspecie},
            {"Listado de mascotas ordenadas por edad", ListaMascotasEdad},
            {"Buscar mascota",buscarMascotasSocio},
            {"Cambiar dueño",cambiarDuenos},
            {"Listado de Socios",verSocios},
            {"Dar de baja a un Socio",bajaSocio},
            {"Registrar a un socio",darAltaSocio},
            {"Registrar una mascota",registrarMascota},
            {"Dar de baja a una mascota",darBajaMascota},
        };
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string eleccion = vista.TryObtenerElementoDeLista("Opciónes:", opciones.Keys.ToList(), "Elija una opción");
                    opciones[eleccion].Invoke();
                    vista.MostrarYReturn("Pulsa <ENTER> para continuar");
                    vista.LimpiarPantalla();
                }
                catch { return; }
            }
        }

        public void darAltaSocio()
        {
            string _dni = vista.TryObtenerDatoDeTipo<string>("Introduzca su DNI");
            if (MascotaSocioGestor.buscarSocio(_dni) == null)
            {
                string name = vista.TryObtenerDatoDeTipo<string>("Introduzca su nombre");
                Sexo sex = vista.TryObtenerElementoDeLista<Sexo>("Elija su sexo", vista.EnumToList<Sexo>(), "Introduzca numero de la lista");
                Socio socio = new Socio
                {
                    dni = _dni,
                    nombre = name,
                    sexo = sex
                };
                MascotaSocioGestor.altaSocio(socio);
            }
            else { vista.Mostrar("El socio ya está registrado"); }
        }

        public void darBajaMascota()
        {
            List<Mascota> mascotas = MascotaSocioGestor.mascotas;
            Mascota mascota = vista.TryObtenerElementoDeLista("Elija la mascota", mascotas, "Introduzca numero de la de la mascota");
            if (vista.Confirmar("Desea continuar?"))
            {
                MascotaSocioGestor.bajaMascota(mascota);
            }
        }

        public void registrarMascota()
        {
            List<Socio> socios = MascotaSocioGestor.socios;
            Socio socio = vista.TryObtenerElementoDeLista("ELija el dueño de la mascota", socios, "elija dueño");
            string nombreMascota = vista.TryObtenerDatoDeTipo<string>("Introduzca el nombre de la mascota");
            Especie especieMascota = vista.TryObtenerElementoDeLista<Especie>("Especie de la mascota:", vista.EnumToList<Especie>(), "Introduzca numero de la lista");
            DateTime fechaMascota = vista.TryObtenerFecha("Introduzca fecha de nacimiento");
            Mascota mascota = new Mascota
            {
                fechaM = fechaMascota,
                nombre = nombreMascota,
                especie = especieMascota,
                dniSocio = socio.dni,
                dueno = socio,
            };
            MascotaSocioGestor.altaMascota(mascota);
        }

        public void buscarMascotasSocio()
        {
            List<Socio> socios = MascotaSocioGestor.socios;
            Socio socio = vista.TryObtenerElementoDeLista("Elija un socio ", socios, "Introduzca número de un socio");
            List<Mascota> mascotas = MascotaSocioGestor.mascotasSocio(socio);
            vista.MostrarListaEnumerada($"{socio.nombre},Mascota:", mascotas);
        }

        public void verSocios()
        {
            List<Socio> socios = MascotaSocioGestor.socios;
            vista.MostrarListaEnumerada("Socios:", socios);
        }

        public void cambiarDuenos()
        {
            List<Mascota> mascotas = MascotaSocioGestor.mascotas;
            Mascota mascota = vista.TryObtenerElementoDeLista("Elija la mascota", mascotas, "Elija una mascota(número)");
            List<Socio> socios = MascotaSocioGestor.socios;
            Socio socio = vista.TryObtenerElementoDeLista("Elija un nuevo propietario", socios, "Elija una persona(número)");
            MascotaSocioGestor.comprarMascota(mascota, socio);
        }
        public void ListaMascotasEspecie()
        {
            List<Mascota> mascotas = MascotaSocioGestor.mascotasPorEspecie();
            vista.MostrarListaEnumerada("Mascotas ordenadas por especie", mascotas);
        }
        public void bajaSocio()
        {
            List<Socio> socios = MascotaSocioGestor.socios;
            Socio socio = vista.TryObtenerElementoDeLista("Baja de un socio", socios, "Introduzca numero de lista del socio");
            List<Mascota> mascotas = MascotaSocioGestor.mascotasSocio(socio);
            vista.MostrarListaEnumerada("las mascotas del socio elegido serán eliminadas", mascotas);
            if (vista.Confirmar("Deseas continuar?"))
            {
                mascotas.ForEach(mascota => MascotaSocioGestor.bajaMascota(mascota));
                MascotaSocioGestor.bajaSocio(socio);
            }
        }
        public void ListaMascotasEdad()
        {
            List<Mascota> mascotas = MascotaSocioGestor.mascotaPorEdad();
            vista.MostrarListaEnumerada("Mascotas por edad", mascotas);
        }
    }
}