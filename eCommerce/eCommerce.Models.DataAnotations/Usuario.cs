using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    /*
     * [Table] = definir o nome da tabela
     * [Colum] = definir o nome da coluna
     * [NotMapped] = não mapear uma propriedade
     * [ForeingKey] = define a propriedade que é uma fk
     * [InverseProperty] = define a referencia de chave na mesma tabela
     * [DatabaseGenerated] = propriedade gerenciada pelo DB
     * 
     * 
     * DataAnotations:
     * [Key] = define a PK
     * 
     * EF Core
     * [Index] = definir/criar indice no banco (x => unique)
     */
    [Index(nameof(Email), IsUnique = true, Name = "IX_EMAIL_UNICO")]
    [Index(nameof(Nome), nameof(Cpf))]
    [Table("TB_USUARIOS")]
    public class Usuario
    {
        
        //Convenção: Id ou <nomeClasse>Id = PK
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //gerenciado pelo banco mas aceita o que vier da aplicação.
        public int Id { get; set; }

        /*

        [Key]
        //Utilizado quando a chave sai da nomenclatura padrão
        [Column("COD")]
        public int Codigo { get; set; }
        */

        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;

        [Required]//torna o campo nulo no banco
        [MaxLength(15)]//tamanho maximo de caracteres
        public string? Sexo { get; set; }

        [Column("Registro_Geral")]
        public string? Rg { get; set; }
        public string Cpf { get; set; } = null!;
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }
        public string? SituacaoCadastro { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Identity, torna a propriedade gerenciada pelo banco UNICA auto incrementada.
        public int Matricula { get; set; }

        [NotMapped]
        //propriedade utilizada apenas na aplicação, não persistido no banco.
        public bool ResgistroAtivo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //Gerenciada pelo banco utililzando uma função ex.: GETDATE()
        public DateTimeOffset DataCadastro { get; set; }

        public Contato? Contato { get; set; }

        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }

        public ICollection<Departamento>? Departamentos { get; set;}

        [InverseProperty("Cliente")]//nome da propriedade navegavel na classe Pedido
        public ICollection<Pedido> PedidosCompradosPeloCliente { get; set; }

        [InverseProperty("Colaborador")]//nome da propriedade navegavel na classe Pedido
        public ICollection<Pedido> PedidosGerenciadosPeloColaborador { get; set; }

        [InverseProperty("Supervisor")]//nome da propriedade navegavel na classe Pedido
        public ICollection<Pedido> PedidosSupervisionadosPeloSupervisor {  get; set; }
    }
}
