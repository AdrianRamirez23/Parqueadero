using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Parqueadero.DTOs
{
    public class ImportesDTO
    {
        [Key]
        [JsonPropertyName("idRegistro")]
        public int? IdRegistro { get; set; }
        [JsonPropertyName("fechaEntrada")]
        [DataType(DataType.DateTime)]
        public DateTime FechaEntrada { get; set; }
        [JsonPropertyName("fechaSalida")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaSalida { get; set; }
        [Required(ErrorMessage ="El campo placa es requerido")]
        [JsonPropertyName("placa")]
        [MaxLength(9,  ErrorMessage ="La estrutuca de la placa debe ser XXX-00000")]
        [MinLength(9, ErrorMessage = "La estrutuca de la placa debe ser XXX-00000")]
        public string Placa { get; set; } = null!;
        [JsonPropertyName("tiempoTotal")]
        public double? TiempoTotal { get; set; }
        [JsonPropertyName("tiempoAcumulado")]
        public double? TiempoAcumulado { get; set; }
        [JsonPropertyName("importe")]
        public double? Importe1 { get; set; }
        [JsonPropertyName("estado")]
        public int? Estado { get; set; }
    }
}
