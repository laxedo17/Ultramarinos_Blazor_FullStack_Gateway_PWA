namespace TendaUltramarinos.Api.Entidades
{
    /// <summary>
    /// Representa a un usuario anque como substituto para usar
    /// auth e identity, os cales non estan incluidos na app
    /// e estara centrada no funcionamento da cesta da compra
    /// e non nunha funcionalidade de estar rexistrado na web
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
    }
}
