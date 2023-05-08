using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Parqueadero.DTOs
{
    public class TiposUsuariosDTO
    {
        [Key]
        [JsonPropertyName("idTipoUsuario")]
        public int? IdTipoUsuario { get; set; }
        [JsonPropertyName("tipoUsuario")]
        [Required(ErrorMessage = "El campo tipo usuario es requerido")]
        [MaxLength(50 , ErrorMessage = "El campo tipo usuario solo recibe hasta 50 caracteres")]
        [MinLength(5 , ErrorMessage = "El campo tipo usuario solo recibe desde 5 caracteres en adelante")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "El campo tipo usuario solo recibe caracteres del alfabeto")]
        public string TipoUsuario { get; set; }
    }
}
