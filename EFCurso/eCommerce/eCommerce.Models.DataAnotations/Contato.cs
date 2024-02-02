using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Contato
    {
        public int Id { get; set; }

        ////Convenção do EF para definir FK
        //public int UsuarioId { get; set; }

        //Fora da convenção
        [ForeignKey("Usuario")]
        //Anotation que indica qual é a FK da tabela dentro dos parênteses.
        public int IdentificadorUsuario { get; set; }

        public string? Telefone { get; set; }
        public string? Celular { get; set; }


        /*
         * POO (Navegar entre objetos relacionados)
         */
        public Usuario? Usuario { get; set; }
    }
}
