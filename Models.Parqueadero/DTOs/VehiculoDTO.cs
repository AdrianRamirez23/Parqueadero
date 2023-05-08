using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Parqueadero.DTOs
{
    public class VehiculoDTO
    {
        [Key]
        [Required(ErrorMessage = "El campo placa es requerido")]
        [JsonPropertyName("placa")]
        public string Placa { get; set; } = null!;
        [JsonPropertyName("estado")]
        [Required(  ErrorMessage = "El campo it tipo vehículo es requerido")]
        [Range(1,9, ErrorMessage = "El rango para el campo id tipo vehiculo es entre 1 y 9")]
        public int IdTipoVehiculo { get; set; }
    }
}
