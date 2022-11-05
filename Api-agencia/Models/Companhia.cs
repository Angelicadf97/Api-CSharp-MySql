using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_agencia.Models
{
    [Table("companhia")]
    public class Companhia
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o cnpj da companhia")]
        [StringLength(18)]
        public String Cnpj { get; set; }

        [Required(ErrorMessage = "Informe o nome da companhia")]
        [StringLength(100)]
        public String Nome { get; set; }
    }
}
