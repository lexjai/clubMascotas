using Clubdata;
using App;
using Consola;

MascotaSocio gestor = new MascotaSocio();
Controlador controlador = new Controlador(gestor);
controlador.Run();

