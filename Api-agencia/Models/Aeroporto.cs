using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_agencia.Models
{
    [Table("aeroporto")]
    public class Aeroporto
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o cnpj do aeroporto")]
        [StringLength(18)]
        public String Cnpj { get; set; }

        [Required(ErrorMessage = "Informe o nome do aeroporto")]
        [StringLength(100)]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Informe a cidade do aeroporto")]
        [StringLength(100)]
        public String Cidade { get; set; }
    }
}
