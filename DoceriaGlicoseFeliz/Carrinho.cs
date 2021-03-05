namespace DoceriaGlicoseFeliz
{
    public class Carrinho 
    {
        public string NomeProduto { get; set; }
        public double PrecoProduto { get; set; }
        public int Quantidade { get; set; }

        public Carrinho(string nome, double preco, int qnt)
        {
            NomeProduto = nome; 
            PrecoProduto = preco;
            Quantidade = qnt;
        }


    }
}
