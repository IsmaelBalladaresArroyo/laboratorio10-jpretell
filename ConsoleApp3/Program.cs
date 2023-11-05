using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            NegociosDataContext BD = new NegociosDataContext();

            var sql = from p in BD.PRODUCTO
                      where p.IdCategoria == 1
                      select p;

            foreach(var item in sql)
            {
                Console.WriteLine("Nombre: {0};Categoria: {1}",
                    item.NombreProducto, item.CATEGORIA.NombreCategoria);
            }
            Console.ReadKey();
        }
    }
}
