namespace Domain.Entities
{
    public class ReceitaCategoria : BaseEntity
    {
        public int ReceitaId { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public Receita Receita { get; set; }
    }
}
