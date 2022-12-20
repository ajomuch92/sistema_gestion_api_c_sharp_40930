using SistemaGestion.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion.Repositories
{
    public class VentaRepository
    {
        private SqlConnection? conexion;
        private String cadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
            "Database=ajomuch92_coderhouse_csharp_40930;" +
            "User Id=ajomuch92_coderhouse_csharp_40930;" +
            "Password=ElQuequit0Sexy2022;";

        public VentaRepository()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
            }
            catch (Exception ex)
            {

            }
        }

        public void RegistrarVenta(Venta venta)
        {
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Venta(Comentarios, IdUsuario) VALUES(@comentarios, @idUsuario); SELECT @@Identity", conexion))
                {
                    conexion.Open();
                    cmd.Parameters.Add(new SqlParameter("comentarios", SqlDbType.VarChar) { Value = venta.Comentario });
                    cmd.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.Float) { Value = venta.IdUsuario });
                    venta.Id = long.Parse(cmd.ExecuteScalar().ToString());
                    if (venta.ProductosVendidos != null && venta.ProductosVendidos.Count > 0)
                    {
                        foreach(ProductoVendido productoVendido in venta.ProductosVendidos)
                        {
                            productoVendido.IdVenta = venta.Id;
                            ProductoVendido productoVendidoRegistrado = RegistrarProducto(productoVendido);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        private ProductoVendido RegistrarProducto(ProductoVendido productoVendido)
        {
            Producto? producto = ProductosRepository.obtenerProductoSimplificadoPorId(productoVendido.IdProducto, conexion);
            if (producto != null)
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ProductoVendido(Stock, IdProducto, IdVenta) VALUES(@stock, @idProducto, @idVenta); SELECT @@Identity;", conexion))
                {
                    cmd.Parameters.Add(new SqlParameter("stock", SqlDbType.BigInt) { Value = productoVendido.Stock });
                    cmd.Parameters.Add(new SqlParameter("idProducto", SqlDbType.Int) { Value = productoVendido.IdProducto });
                    cmd.Parameters.Add(new SqlParameter("idVenta", SqlDbType.BigInt) { Value = productoVendido.IdVenta });
                    productoVendido.Id = long.Parse(cmd.ExecuteScalar().ToString());
                }
                DisminuiStock(producto, productoVendido.Stock);
            }
            else
            {
                throw new Exception("Producto no encontrado");
            }
            return productoVendido;
        }

        private void DisminuiStock(Producto producto, int cantidadVendida)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Producto SET stock = @stock WHERE id = @id", conexion))
            {
                cmd.Parameters.Add(new SqlParameter("stock", SqlDbType.Int) { Value = producto.Stock - cantidadVendida });
                cmd.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = producto.Id });
                cmd.ExecuteNonQuery();
            }
        }
    }
}
