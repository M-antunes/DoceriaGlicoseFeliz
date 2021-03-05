namespace DoceriaGlicoseFeliz
{
    public class Produto
    {
        public string NomeProduto { get; set; }
        public double PrecoProduto { get; set; }

        public Produto(string nome, double preco)
        {
            NomeProduto = nome;
            PrecoProduto = preco;
        }

        public string ExibirProdutos()
        {
            return this.NomeProduto;
        }
    }
}
