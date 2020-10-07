using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LuisDavidGil_P1_AP2.Data;
using LuisDavidGil_P1_AP2.Models;
using System;
using LuisDavidGil_P1_AP2.DAL;

namespace LuisDavidGil_P1_AP2.BLL
{

    public class ProductosBLL
    {

        public static bool Guardar(Productos producto)
        {
            if (!Existe(producto.id))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        private static bool Existe(int id)
        {
            bool existencia;
            Contexto contexto = new Contexto();

            try
            {
                existencia = contexto.Productos.Any(p => p.id == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return existencia;
        }

        private static bool Insertar(Productos producto)
        {
            bool guardado;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Productos.Add(producto);
                guardado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardado;
        }

        private static bool Modificar(Productos producto)
        {
            bool modificado;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }

        public static bool Eliminar(int id)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Productos.Find(id);

                if (eliminar != null)
                {
                    contexto.Entry(eliminar).State = EntityState.Deleted;
                    eliminado = (contexto.SaveChanges() > 0);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }

        public static Productos Buscar(int id)
        {
            Productos producto = new Productos();
            Contexto contexto = new Contexto();

            try
            {
                producto = contexto.Productos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return producto;
        }
    }
}
