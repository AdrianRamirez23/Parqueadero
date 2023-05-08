using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Parqueadero.DTOs
{
    public class EmpleadosDTO
    {
        [Key]
        [JsonPropertyName("id")]
        [Required(ErrorMessage = "El campo id es requerido")]
        [MaxLength(13, ErrorMessage = "El valor máximo para el id es de 13 caracteres")]
        [MinLength(6, ErrorMessage = "El valor mínimo para el id es de 6 caracteres")]
        public string Id { get; set; }
        [JsonPropertyName("nombres")]
        [Required(ErrorMessage = "El campo nombres es requerido")]
        [MaxLength(100, ErrorMessage = "El valor máximo para el nombre es de 100 caracteres")]
        [MinLength(3, ErrorMessage = "El valor mínimo para el nombre es de 3 caracteres")]
        public string Nombres { get; set; }
        [JsonPropertyName("correo")]
        [Required(ErrorMessage = "El campo correo es requerido")]
        [MaxLength(100, ErrorMessage = "El valor máximo para el correo es de 100 caracteres")]
        [MinLength(10, ErrorMessage = "El valor mínimo para el correo es de 10 caracteres")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email válido.")]
        public string Correo { get; set; }
        [JsonPropertyName("celular")]
        [Required(ErrorMessage = "El campo celular es requerido")]
        [MaxLength(13, ErrorMessage = "El valor máximo para el celular es de 100 caracteres")]
        [MinLength(10, ErrorMessage = "El valor mínimo para el celular es de 10 caracteres")]
        public string Celular { get; set; }
        [JsonPropertyName("contrasena")]
        [Required(ErrorMessage = "El campo contraseña es requerido")]
        [MaxLength(20, ErrorMessage = "El valor máximo para el contraseña es de 20 caracteres")]
        [MinLength(8, ErrorMessage = "El valor mínimo para el contraseña es de 8 caracteres")]
        public string Contrasena { get; set; }
        [JsonPropertyName("tipoUsuario")]
        [Required(ErrorMessage = "El campo tipo usuario es requerido")]
        [Range(1, 9, ErrorMessage = "El rango para el campo id tipo usuario es entre 1 y 9")]
        public int TipoUsuario { get; set; }
    }
}
