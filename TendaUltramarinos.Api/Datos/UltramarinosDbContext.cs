using Microsoft.EntityFrameworkCore;

using TendaUltramarinos.Api.Entidades;

namespace TendaUltramarinos.Api.Datos
{
    public class UltramarinosDbContext : DbContext
    {
        public UltramarinosDbContext(DbContextOptions<UltramarinosDbContext> options) : base(options)
        {

        }

        public DbSet<Cesta> Cestas { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<CestaItem> CestaItems { get; set; }
        public DbSet<ProductoCategoria> ProductoCategorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Seeding de datos para comenzar a BD con algún dato para EF Core, usando Code First e non Database First
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Productos
            //Categoria Beleza
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 1,
                Nome = "Glossier - Kit de Beleza",
                Descripcion = "Un kit fabricado por Glossier, que conten productos para o coidado da pel, do pelo e maquillaxe",
                ImaxeUrl = "/Imaxes/Beleza/Beleza1.png",
                Precio = 100,
                Cantidade = 100,
                CategoriaId = 1

            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 2,
                Nome = "Curology - Kit Coidado da Pel",
                Descripcion = "Un kit de Curology, que inclue productos para coidar a tua pel",
                ImaxeUrl = "/Imaxes/Beleza/Beleza2.png",
                Precio = 50,
                Cantidade = 45,
                CategoriaId = 1

            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 3,
                Nome = "Cocooil - Aceite de Coco Organico",
                Descripcion = "Un kit de Curology, que conten productos para o coidado da pel",
                ImaxeUrl = "/Imaxes/Beleza/Beleza3.png",
                Precio = 20,
                Cantidade = 30,
                CategoriaId = 1

            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 4,
                Nome = "Schwarzkopf - Kit de coidado do pelo e da pel",
                Descripcion = "Un conxunto de productos de Schwarzkopf, que conten productos para o coidado da pel e do pelo",
                ImaxeUrl = "/Imaxes/Beleza/Beleza4.png",
                Precio = 50,
                Cantidade = 60,
                CategoriaId = 1

            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 5,
                Nome = "Kit Coida Peles",
                Descripcion = "Outro dos kits para coidar a tua pel e o teu pelo, a beleza e o mais importante.",
                ImaxeUrl = "/Imaxes/Beleza/Beleza5.png",
                Precio = 30,
                Cantidade = 85,
                CategoriaId = 1

            });
            //Categoria Electronica
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 6,
                Nome = "Air Pods",
                Descripcion = "Air Pods - auriculares de tapón sen cables ao alcance do oído, e da tua carteira",
                ImaxeUrl = "/Imaxes/Electronica/Electronica1.png",
                Precio = 100,
                Cantidade = 120,
                CategoriaId = 3

            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 7,
                Nome = "Auriculares Golden ao alcance do oído",
                Descripcion = "Auriculares Golden ao alcance do oído - estes auriculares non son wireless",
                ImaxeUrl = "/Imaxes/Electronica/Electronica2.png",
                Precio = 40,
                Cantidade = 200,
                CategoriaId = 3

            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 8,
                Nome = "Auriculares de Diadema Black",
                Descripcion = "Auriculares Black - non son wireless",
                ImaxeUrl = "/Imaxes/Electronica/Electronica3.png",
                Precio = 40,
                Cantidade = 300,
                CategoriaId = 3

            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 9,
                Nome = "Sennheiser Digital Camera con Tripode",
                Descripcion = "Sennheiser Digital Camera - Camara dixital de alta calidade fabricada por Sennheiser - inclue tripode",
                ImaxeUrl = "/Imaxes/Electronica/Electronica4.png",
                Precio = 600,
                Cantidade = 20,
                CategoriaId = 3

            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 10,
                Nome = "Canon Digital Camera",
                Descripcion = "Canon Digital Camera - Camara dixital de alta calidade de Canon",
                ImaxeUrl = "/Imaxes/Electronica/Electronica5.png",
                Precio = 500,
                Cantidade = 15,
                CategoriaId = 3

            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 11,
                Nome = "Nintendo Gameboy",
                Descripcion = "Gameboy - De Nintendo. A gameboy clásica da tua infancia",
                ImaxeUrl = "/Imaxes/Electronica/electronica6.png",
                Precio = 100,
                Cantidade = 60,
                CategoriaId = 3
            });
            //Categoria Mobles
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 12,
                Nome = "Silla de Oficina de Coiro Negro",
                Descripcion = "Unha silla moi comoda para mentes inquietas",
                ImaxeUrl = "/Imaxes/Mobles/Mobles1.png",
                Precio = 50,
                Cantidade = 212,
                CategoriaId = 2
            });

            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 13,
                Nome = "Silla de Oficina de Coiro Rosa",
                Descripcion = "Silla de oficina con sensibilidade a flor de pel e cor de bonitas plantas",
                ImaxeUrl = "/Imaxes/Mobles/Mobles2.png",
                Precio = 50,
                Cantidade = 112,
                CategoriaId = 2
            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 14,
                Nome = "Silla de Salon",
                Descripcion = "Unha silla moi comoda para sentarse durante horas",
                ImaxeUrl = "/Imaxes/Mobles/Mobles3.png",
                Precio = 70,
                Cantidade = 90,
                CategoriaId = 2
            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 15,
                Nome = "Silla de Salon Plateada",
                Descripcion = "Comodisima e destellante como o cromo, para impactar as tuas visitas",
                ImaxeUrl = "/Imaxes/Mobles/Mobles4.png",
                Precio = 120,
                Cantidade = 95,
                CategoriaId = 2
            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 16,
                Nome = "Lampara de Mesa de Porcelana",
                Descripcion = "Lampara de mesa de porcelana branca e azul que ni Porcelanosa a facía tan bonita",
                ImaxeUrl = "/Imaxes/Mobles/Mobles6.png",
                Precio = 15,
                Cantidade = 100,
                CategoriaId = 2
            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 17,
                Nome = "Lampara de Mesa de Oficina",
                Descripcion = "Unha lampara de mesa que esta ahi, pero pasa desapercibida",
                ImaxeUrl = "/Imaxes/Mobles/Mobles7.png",
                Precio = 20,
                Cantidade = 73,
                CategoriaId = 2
            });
            //Categoria Calzado
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 18,
                Nome = "Tenis Puma",
                Descripcion = "Tenis moi comodos en diferentes tamaños",
                ImaxeUrl = "/Imaxes/Calzado/Calzado1.png",
                Precio = 100,
                Cantidade = 50,
                CategoriaId = 4
            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 19,
                Nome = "Deportivas coloridas",
                Descripcion = "Unhas moi coloridas zapatillas deportivas disponibles en diferentes tamanhos para ti",
                ImaxeUrl = "/Imaxes/Calzado/Calzado2.png",
                Precio = 150,
                Cantidade = 60,
                CategoriaId = 4
            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 20,
                Nome = "Tenis Blue Nike",
                Descripcion = "Tenis Blue Nike Trainers - porque ti o vales",
                ImaxeUrl = "/Imaxes/Calzado/Calzado3.png",
                Precio = 200,
                Cantidade = 70,
                CategoriaId = 4
            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 21,
                Nome = "Deportivas Coloridas Hummel",
                Descripcion = "Colorful Hummel Trainers - available in most sizes",
                ImaxeUrl = "/Imaxes/Calzado/Calzado4.png",
                Precio = 120,
                Cantidade = 120,
                CategoriaId = 4
            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 22,
                Nome = "Deportivas Nike Vermellas",
                Descripcion = "Unhas zapatillas elegantes disponhibles en varios tamanhos",
                ImaxeUrl = "/Imaxes/Calzado/Calzado5.png",
                Precio = 200,
                Cantidade = 100,
                CategoriaId = 4
            });
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                Id = 23,
                Nome = "Sandalias Birkenstock",
                Descripcion = "Sandalias para xente chic",
                ImaxeUrl = "/Imaxes/Calzado/Calzado6.png",
                Precio = 50,
                Cantidade = 150,
                CategoriaId = 4
            });

            //Engadindo Usuarios
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                NomeUsuario = "Laurie"

            });
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 2,
                NomeUsuario = "Sara"

            });

            //Crea Cesta da Compra para Usuarios
            modelBuilder.Entity<Cesta>().HasData(new Cesta
            {
                Id = 1,
                UsuarioId = 1

            });
            modelBuilder.Entity<Cesta>().HasData(new Cesta
            {
                Id = 2,
                UsuarioId = 2

            });
            //Engade Categorias de Producto
            modelBuilder.Entity<ProductoCategoria>().HasData(new ProductoCategoria
            {
                Id = 1,
                Nome = "Beleza",
                IconoCss = "fas fa-spa"
            });
            modelBuilder.Entity<ProductoCategoria>().HasData(new ProductoCategoria
            {
                Id = 2,
                Nome = "Mobles",
                IconoCss = "fas fa-couch"
            });
            modelBuilder.Entity<ProductoCategoria>().HasData(new ProductoCategoria
            {
                Id = 3,
                Nome = "Electronica",
                IconoCss = "fas fa-headphones"
            });
            modelBuilder.Entity<ProductoCategoria>().HasData(new ProductoCategoria
            {
                Id = 4,
                Nome = "Calzado",
                IconoCss = "fas fa-shoe-prints"
            });

        }
    }
}
