namespace Domain.Entities
{
    public class ReceitaCategoria
    {
        public int ReceitaId { get; set; }
        public int CategoriaId { get; set; }
        public virtual Receita Receita { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
