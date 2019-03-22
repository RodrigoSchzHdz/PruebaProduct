using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Entity
{
    public class EntityProduct
    {
        public void GuardarProducto(ProductModel modelo)
        {
            using(testEntities db = new testEntities())
            {
                db.Product.Add(new Product
                {
                    nombre = modelo.nameProduct,
                    fecha_alta = DateTime.Now,
                    estatus = 1
                });
                db.SaveChanges();
            }
        }

        public List<Product> ObtenerProductos()
        {
            using (testEntities db = new testEntities())
            {
                var datos = (from x in db.Product select x).ToList();
                return datos;
            }
        }

       public bool EditarProducto(int edit, string nombre)
        {
            using (testEntities db = new testEntities())
            {
                var datos = (from x in db.Product where x.id == edit select x).ToList();
                if (datos.Count() > 0)
                {
                    var actual = datos.FirstOrDefault();
                    actual.nombre = nombre;
                    actual.fecha_alta = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool EliminarProducto(int deletes)
        {
            using (testEntities db = new testEntities())
            {
                var datos = (from x in db.Product where x.id == deletes select x).ToList();
                if (datos.Count() > 0)
                {
                    var actual = datos.FirstOrDefault();
                    db.Product.Remove(actual);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}