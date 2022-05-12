namespace TendaUltramarinos.Api.Entidades
{
    public class ProductoCategoria
    {
        //Id e a tipica propiedade que usara Entity Framework Core
        //para representar a primary key, por iso se pon por convencion
        public int Id { get; set; }
        public string Nome { get; set; }
        public string IconoCss { get; set; }

    }
}
