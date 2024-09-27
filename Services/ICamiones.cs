using DTO;
using System.Data.Entity.Validation;
using System.Text.RegularExpressions;
using TransportesApi.Models;

namespace TransportesApi.Services
{
    public interface ICamiones
    {
        //es una estructura que define un contrato o conjunto de métodos y
        //propiedades que una clase debe implementar.
        //Una interfaz establece un conjunto de requisitos que cualquier clase
        //que la implemente debe seguir. Estos requisitos son declarados en la
        //interfaz en forma de firmas de métodos y propiedades,
        //pero la interfaz en sí misma no proporciona ninguna implementación
        //de estos métodos o propiedades.Es responsabilidad de las clases que
        //implementan la interfaz proporcionar las implementaciones concretas de
        //estos miembros.

        //Las interfaces son útiles para lograr la abstracción y la reutilización
        //de código en C#.

        //GET 
        List<Camiones> GetCamiones();

        //GETbyID
        CamionesDTO GetCamionByID(int id);

        //Insert
        string InsertCamion(CamionesDTO camion);
        //UPDATE
        string updateCamion(CamionesDTO camion);
        //Delete
        string DeleteCamion(int id);

    }
    public class CamionesService : ICamiones
    {
        //variable contexto
        private readonly TransporteContext _context;
        //incializar context
        public CamionesService(TransporteContext context)
        {
            this._context = context;
        }

        public string DeleteCamion(int id)
        {
            try
            {
                Camiones _camion = _context.Camiones.Find(id);
                Camiones _camion2 = _context.Camiones.FirstOrDefault(c => c.Id_Camion == id);
                Camiones _camion3 = _context.Camiones.Where(c => c.Id_Camion == id).FirstOrDefault();
                Camiones _camion4 = (from c in _context.Camiones where c.Id_Camion == id select c).FirstOrDefault();

                if (_camion != null)
                {
                    try
                    {

                        _context.Camiones.Remove(_camion);
                        _context.SaveChanges();

                        return "se guardo correctamente";
                    }
                    catch (DbEntityValidationException ex)
                    {
                        string resp = "";
                        //Recorro todos los posibles errores de la entidad Referencial 
                        foreach (var error in ex.EntityValidationErrors)
                        {
                            //Recorro los detalles de cada error
                            foreach (var validationError in error.ValidationErrors)
                            {
                                resp = "Error en la Entidad: " + error.Entry.Entity.GetType().Name;
                                resp += validationError.PropertyName;
                                resp += validationError.ErrorMessage;
                            }
                        }
                        return resp;
                    }
                }
                else
                {
                    return $"NO SE ENCONTRO EL OBOJETO CON ID {id}";
                }
            }
            catch (Exception ex)
            {

                return "error: " + ex.Message;
            }
        }

        public CamionesDTO GetCamionByID(int id)
        {
            CamionesDTO respuesta = new CamionesDTO();
            Camiones _camion = _context.Camiones.Find(id);
            if (_camion != null)
            {

                respuesta.Id_Camion = _camion.Id_Camion;
                respuesta.matricula = _camion.matricula;
                respuesta.capacidad = _camion.capacidad;
                respuesta.tipo_camion = _camion.tipo_camion;
                respuesta.urlfoto = _camion.urlfoto;
                respuesta.marca = _camion.marca;
                respuesta.modelo = _camion.modelo;
                respuesta.kilometraje = _camion.kilometraje;
                respuesta.disponibilidad = _camion.disponibilidad;
            }
            return respuesta;

        }



        public List<Camiones> GetCamiones()
        {
            List<Camiones> lista_camiones = _context.Camiones.ToList();
            return lista_camiones;
        }

        public string InsertCamion(CamionesDTO camion)
        {
            try
            {
                Camiones _camion = new Camiones();

                _camion.Id_Camion = _camion.Id_Camion;
                _camion.matricula = _camion.matricula;
                _camion.capacidad = _camion.capacidad;
                _camion.tipo_camion = _camion.tipo_camion;
                _camion.urlfoto = _camion.urlfoto;
                _camion.marca = _camion.marca;
                _camion.modelo = _camion.modelo;
                _camion.kilometraje = _camion.kilometraje;
                _camion.disponibilidad = _camion.disponibilidad;

                try
                {
                    _context.Camiones.Add(_camion);
                    _context.SaveChanges();
                    return "se inserto correctamente";
                }
                catch (DbEntityValidationException ex)
                {
                    string resp = "";
                    //Recorro todos los posibles errores de la entidad Referencial 
                    foreach (var error in ex.EntityValidationErrors)
                    {
                        //Recorro los detalles de cada error
                        foreach (var validationError in error.ValidationErrors)
                        {
                            resp = "Error en la Entidad: " + error.Entry.Entity.GetType().Name;
                            resp += validationError.PropertyName;
                            resp += validationError.ErrorMessage;
                        }
                    }
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return "Error: "+ex.Message;    
            }
        }

        public string updateCamion(CamionesDTO camion)
        {
            try
            {
                Camiones _camion = new Camiones();

                _camion.Id_Camion = _camion.Id_Camion;
                _camion.matricula = _camion.matricula;
                _camion.capacidad = _camion.capacidad;
                _camion.tipo_camion = _camion.tipo_camion;
                _camion.urlfoto = _camion.urlfoto;
                _camion.marca = _camion.marca;
                _camion.modelo = _camion.modelo;
                _camion.kilometraje = _camion.kilometraje;
                _camion.disponibilidad = _camion.disponibilidad;

                try
                {
                    _context.Entry(_camion).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return "se actualizo correctamente";
                }
                catch (DbEntityValidationException ex)
                {
                    string resp = "";
                    //Recorro todos los posibles errores de la entidad Referencial 
                    foreach (var error in ex.EntityValidationErrors)
                    {
                        //Recorro los detalles de cada error
                        foreach (var validationError in error.ValidationErrors)
                        {
                            resp = "Error en la Entidad: " + error.Entry.Entity.GetType().Name;
                            resp += validationError.PropertyName;
                            resp += validationError.ErrorMessage;
                        }
                    }
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        //implementacion de metodos

    }
}
