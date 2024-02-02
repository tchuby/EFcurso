using Microsoft.EntityFrameworkCore;

namespace eCommerce.Models.FluentAPI
{
    public class eCommerceFluentContext : DbContext
    {
        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        {

        }

        //DbSet representa cada tabela, o nome dessa propriedade será o nome da tabela,
        //nesse caso o EF criará uma tabela no banco chamada Usuarios.
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * Table, Column, NotMapped, DatabaseGenerated
             */
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");// ToTable dá o nome a tabela

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Rg)
                .HasColumnName("REGISTRO_GERAL")
                .HasMaxLength(10)
                .HasDefaultValue("RG_AUSENTE")
                .IsRequired();

            modelBuilder.Entity<Usuario>().Ignore(x => x.Sexo);//NotMapped

            modelBuilder.Entity<Usuario>().Property(x => x.Id).ValueGeneratedOnAdd(); //DatabaseGenerated

            //Index
            modelBuilder.Entity<Usuario>()
                .HasIndex("Cpf")
                .IsUnique()
                .HasFilter("[Cpf] is not null")
                .HasDatabaseName("IX_CPF_UNIQUE");

            modelBuilder.Entity<Usuario>().HasIndex(a => a.Cpf);

            modelBuilder.Entity<Usuario>().HasIndex("Cpf", "Email");
            modelBuilder.Entity<Usuario>().HasIndex(a => new {a.Cpf, a.Email});

            //Key

            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
            modelBuilder.Entity<Usuario>().HasKey("Id");

            modelBuilder.Entity<Usuario>().HasKey(a => new { a.Cpf, a.Email});

            modelBuilder.Entity<Usuario>().HasAlternateKey("Email");

            modelBuilder.Entity<Usuario>().HasNoKey();

            //ForeignKey
            //Relacionamentos -- Has/With + One/Many -- HasOne, HasMany, WithOne, WithMany

            // 1 x 1, 1 x 1
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Contato)
                .WithOne(c => c.Usuario)
                .HasForeignKey<Contato>(c => c.UsuarioId)//relação um pra um precisa especificar em que tabela <Entity> está a chave estrangeira.
                .OnDelete(DeleteBehavior.Cascade); //Quando as propriedades do DeleteBehavior começar com Client (ClientCascade), significa que o comportamento de Cascade será adotado apenas pelo EF, as configurações do banco serão padrão.

            // 1 x n, n x 1
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.EnderecosEntrega)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId);//um pra muitos o EF infere qual é a tabela que carrega a chave estrangeira.

            // n x n
            modelBuilder.Entity<Usuario>().HasMany(u => u.Departamentos).WithMany(d => d.Usuarios); // não precisa especificar, pois haverá uma tabela intermediária.
        }
    }
}
