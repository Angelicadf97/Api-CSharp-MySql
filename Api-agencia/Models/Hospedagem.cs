using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_agencia.Models
{
    [Table("hospedagem")]
    public class Hospedagem
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o cnpj da hospedagem")]
        [StringLength(18)]
        public String Cnpj { get; set; }

        [Required(ErrorMessage = "Informe o nome da hospedagem")]
        [StringLength(100)]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Informe a cidade da hospedagem")]
        [StringLength(100)]
        public String Cidade { get; set; }

        [Required(ErrorMessage = "Informe o valor da diária")]
        public double Preco_dia { get; set; }

        [Required(ErrorMessage = "Informe o tipo de hospedagem")]
        [StringLength(20)]
        public String Tipo { get; set; }

    }

}
