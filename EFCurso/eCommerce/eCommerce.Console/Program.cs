using eCommerce.Console.Database;

var db = new eCommerceContext();
foreach (var item in db.Usuarios)
{
    Console.WriteLine(item.Nome);
}
