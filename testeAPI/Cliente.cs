namespace testeAPI
{
    public class Cliente
    {
        public DateTime DataNascimento { get; set; }

        public int Cpf { get; set; }

        public int Idade => ObterIdade();

        public string? Nome { get; set; }


        public int ObterIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
    }



}
