using System.ComponentModel.DataAnnotations;

namespace testeAPI
{
    public class Cliente
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Data é obrigatório")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(14, ErrorMessage = "CPF deve conter 11 números")]
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string? Cpf { get; set; }

        public int Idade => ObterIdade();

        [MinLength(1, ErrorMessage = "Nome não pode ser vazio")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string? Nome { get; set; }


        public int ObterIdade()
        {
            if(!DataNascimento.HasValue)
            {
                return -1;
            }
            int idade = DateTime.Now.Year - DataNascimento.Value.Year;
            if (DateTime.Now.DayOfYear < DataNascimento.Value.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
    }



}
