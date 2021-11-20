using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.UserInterface
{
    /// <summary>
    /// Acá es donde se persiste contra la base de datos
    /// </summary>
    public class CategoriaRepository
    {

        public List<Categoria> GetAll()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Nombre, Descripcion FROM Categorias";
                    var entity = new List<Categoria>();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var c = new Categoria()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                Descripcion = Convert.ToString(reader["Descripcion"])
                            };
                            entity.Add(c);
                        }
                    }
                    return entity;
                }
            }
        }

        public void Create(Categoria entity)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Categorias(Nombre, Descripcion) VALUES(@Nombre, @Descripcion)";
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Categoria entity)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion" +
                                     " WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Categoria Single(int id)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Nombre, Descripcion" +
                                     " WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var entity = new Categoria();
                            if (reader.Read())
                            {
                                entity.Id = Convert.ToInt32(reader["Id"]);
                                entity.Nombre = Convert.ToString(reader["Nombre"]);
                                entity.Descripcion = Convert.ToString(reader["Descripcion"]);
                            }
                            return entity;
                        }
                        else
                            return null;
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Categorias WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
