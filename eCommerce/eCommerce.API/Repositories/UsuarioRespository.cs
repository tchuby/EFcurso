using eCommerce.API.Database;
using eCommerce.Models;

namespace eCommerce.API.Repositories
{
    public class UsuarioRespository : IUsuarioRepository
    {
        private readonly eCommerceContext _db;
        public UsuarioRespository(eCommerceContext db)
        {
            _db = db;
        }

        public List<Usuario> GetAll()
        {
            return _db.Usuarios.OrderBy(u => u.Id).ToList();
        }
        
        public Usuario? Get(int id)
        {
            return _db.Usuarios.Find(id);
        }

        public void Add(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }
        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Usuarios.Remove(Get(id)!);
            _db.SaveChanges();
        }
    }
}
