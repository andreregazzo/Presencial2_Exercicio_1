using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presencial2_Exercicio_1.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        [StringLength(8, ErrorMessage = "O CEP deve ter 8 caracteres.")]
        public String Cep { get; set; }
        [MinLength(5, ErrorMessage = "O logradouro deve ter pelo menos 5 caracteres.")]
        public String Logradouro { get; set; }
        public String Complemento { get; set; }
        
        [MinLength(5, ErrorMessage = "O bairro deve ter pelo menos 5 caracteres.")]
        public String Bairro { get; set; }
        public String Localidade { get; set; }

        [StringLength(2, ErrorMessage = "A UF deve ter 2 caracteres.")]
        public String Uf { get; set; }
    }
}
