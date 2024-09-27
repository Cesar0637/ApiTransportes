using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class CamionesDTO
    {
        public int Id_Camion { get; set; }
        public string matricula { get; set; }
        public int capacidad { get; set; }
        public string tipo_camion { get; set; }
        public string urlfoto { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public double kilometraje { get; set; }
        public bool disponibilidad { get; set; }

    }
}
