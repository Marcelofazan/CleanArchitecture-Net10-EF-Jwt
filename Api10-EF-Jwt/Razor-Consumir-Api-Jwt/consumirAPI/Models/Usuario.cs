using consumirAPI.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace consumirAPI.Models
{
    public class Usuario
    {
        [DisplayName("Id Empresa")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdEmpresa { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; } = string.Empty;

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [DisplayName("Taxa Percentual")]
        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal TaxaPercentual { get; set; }

    }
}
