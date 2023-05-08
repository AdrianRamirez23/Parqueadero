using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Parqueadero.DTOs
{
    public class EstadosDTO
    {
        [Key]
        [JsonPropertyName("idEstado")]
        public int? IdEstado { get; set; }
        [JsonPropertyName("estado")]
        [Required(ErrorMessage = "El campo tipo estado es requerido")]
        [MaxLength(50, ErrorMessage = "El campo estado solo recibe hasta 50 caracteres")]
        [MinLength(5, ErrorMessage = "El campo estado solo recibe desde 5 caracteres en adelante")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "El campo estado solo recibe caracteres del alfabeto")]
        public string Estado1 { get; set; }
    }
}
