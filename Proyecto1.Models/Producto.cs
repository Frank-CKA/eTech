using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models //Changed namespace - Sábado 14
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Número de Serie")]
        public string NumeroSerie { get; set; }
        [Required]
        [MaxLength(60)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required]
        [Range(1, 1000000)]
        [Display(Name = "Precio")]
        public double Precio { get; set; }
        [Required]
        [Range(1, 9000000)]
        [Display(Name = "Costo")]
        public double Costo { get; set; }

        public string ImageUrl { get; set; }
        //foreign keys
        [Required]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
        [Required]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }
        //Recursividad
        public int? PadreId { get; set; }
        public virtual Producto Padre { get; set; }
    }
}
