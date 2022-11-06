using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_agencia.Models
{
    [Table("cliente")]
    public class Cliente
    {
        private LocalDataStoreSlot nasc;

        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o cpf do cliente")]
        [StringLength(14)]
        public String Cpf { get; set; }

        [Required(ErrorMessage = "Informe o nome do cliente")]
        [StringLength(100)]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Informe o telefone do cliente")]
        [StringLength(15)]
        public String Tel { get; set; }

        [Required(ErrorMessage = "Informe a senha do cliente")]
        [StringLength(20)]
        public String Senha { get; set; }

        [Required(ErrorMessage = "Informe o email do cliente")]
        [StringLength(100)]
        public String Email { get; set; }

        [Required(ErrorMessage = "Informe o logradouro do cliente")]
        [StringLength(100)]
        public String Logradouro { get; set; }

        [Required(ErrorMessage = "Informe a cidade do cliente")]
        [StringLength(100)]
        public String Cidade { get; set; }
    }
}
