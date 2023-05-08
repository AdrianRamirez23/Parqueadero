using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Parqueadero.DTOs
{
    public class TipoVehiculoDTO
    {
        [Key]
        [JsonPropertyName("idTipoVehiculo")]
        public int? IdTipoVehiculo { get; set; }
        [JsonPropertyName("tipoVehiculo")]
        [Required(ErrorMessage = "El campo tipo vehículo es requerido")]
        [MaxLength(50, ErrorMessage = "El campo tipo vehículo solo recibe hasta 50 caracteres")]
        [MinLength(5, ErrorMessage = "El campo tipo vehículo solo recibe desde 5 caracteres en adelante")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "El campo tipo vehículo solo recibe caracteres del alfabeto")]
        public string TipoVehiculo { get; set; }
        [JsonPropertyName("importePorMinuto")]
        [Required(ErrorMessage = "El campo importe por minuto es requerido")]
        [DataType(DataType.Currency)]
        [Range(0,999999, ErrorMessage = "El rango del campo importe es 0 a 999999")]
        public double ImportePorMinuto { get; set; }
    }
}
