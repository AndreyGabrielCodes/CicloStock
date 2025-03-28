namespace CicloStock.Utilitarios
{
    public class Enumerados
    {
        public enum SituacaoEntrada : short 
        {
            Aberto = 0,
            EmAndamento = 1,
            Concluido = 2,
            Cancelado = 3,
        } 
        public enum SituacaoEntradaLote : short 
        {
            Aberto = 0,
            EmAndamento = 1,
            Concluido = 2,
            Cancelado = 3,
        } 
        public enum SituacaoProduto : short
        {
            Inativo = 0,
            Ativo = 1,
        } 
        public enum SituacaoLocacao : short
        {
            Inativo = 0,
            Principal = 1,
            Alternativo = 2,
        }

        public enum Inconsistencia : short
        {
            ProdutoTrocado = 1,
            ProdutoAvariado = 2,
            SobraDeProduto = 3,
            FaltaDeProduto = 4,
        }
    }
}
