namespace TendaUltramarinos.Api.Entidades
{
    public class CestaItem
    {
        public int Id { get; set; }
        //propiedade que representa un campo de clave foranea de Cesta
        //para unir a entidade Cesta con CestaItem
        //con isto a entidade CestaItem ten unha relacion 1 a moitos
        //coa entidade Cesta
        //Asi podemos ter moitos elementos dentro dunha cesta da compra
        //en particular
        public int CestaId { get; set; }
        //a entidade Producto ten unha relacion 1 a moitos
        //coa entidade CestaItem
        //porque un producto pode incluirse
        //moitas veces en moitas cestas da compra
        public int ProductoId { get; set; }
        public int Cantidade { get; set; }
    }
}
