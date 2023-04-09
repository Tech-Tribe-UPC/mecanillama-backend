namespace Mecanillama.API.Security.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{
    // Conexión a la base de datos
    private static string connectionString = "Data Source=TuServidorDeBD;Initial Catalog=TuBaseDeDatos;User ID=TU_USUARIO;Password=TU_CONTRASEÑA";

    // Método para registrar un nuevo usuario
    public static void RegistrarUsuario(string nombre, string email, string contraseña)
    {
        // Consulta SQL para insertar un nuevo usuario en la tabla de usuarios
        string query = "INSERT INTO Usuarios (Nombre, Email, Contraseña) VALUES (@nombre, @email, @contraseña)";

        // Abrir la conexión a la base de datos
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Crear un comando SQL con la consulta y la conexión a la base de datos
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Agregar los parámetros a la consulta SQL
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@contraseña", contraseña);

                // Ejecutar la consulta SQL
                command.ExecuteNonQuery();
            }

            // Cerrar la conexión a la base de datos
            connection.Close();
        }
    }
}