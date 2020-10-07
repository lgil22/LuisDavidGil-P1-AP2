using System;
using System.ComponentModel.DataAnnotations;


namespace LuisDavidGil_P1_AP2.Models
{
    public class Productos
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage="La descripcion del producto es requerida..."),MaxLength(200)]
        public string Descripcion { get; set; }
        [Required,Range(minimum:1,maximum:int.MaxValue,ErrorMessage = "El costo debe ser minimo 1")]
        public int Existencia { get; set; } = 1;
        [Required]
        public decimal Costo { get; set; } = 0;
        [Required,Range(minimum:0,maximum:int.MaxValue,ErrorMessage = "El costo debe ser minimo 1")]
        public decimal ValorInventario { get; set; }
        
    }
}