using Dapper;
using SoundBitesAPI.Models;
using System.Data;

namespace SoundBitesAPI.Repositories
{
    public class UsuarioRepository
    {
        private readonly IDbConnection _db;

        public UsuarioRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            var sql = "SELECT * FROM Usuario";
            return await _db.QueryAsync<Usuario>(sql);
        }

        public async Task<Usuario?> BuscarPorId(int idUsuario)
        {
            var sql = "SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario";
            return await _db.QueryFirstOrDefaultAsync<Usuario>(sql, new { IdUsuario = idUsuario });
        }

        public async Task<int> GuardarUsuario(Usuario usuario)
        {
            var sql = @"INSERT INTO Usuario (Nombre, Correo, Contraseña, Rol) 
                        VALUES (@Nombre, @Correo, @Contraseña, @Rol)";
            return await _db.ExecuteAsync(sql, usuario);
        }

        public async Task<int> ActualizarUsuario(Usuario usuario)
        {
            var sql = @"UPDATE Usuario 
                        SET Nombre = @Nombre, Correo = @Correo, Contraseña = @Contraseña, Rol = @Rol
                        WHERE IdUsuario = @IdUsuario";
            return await _db.ExecuteAsync(sql, usuario);
        }

        public async Task<int> EliminarUsuario(int idUsuario)
        {
            var sql = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuario";
            return await _db.ExecuteAsync(sql, new { IdUsuario = idUsuario });
        }
    }
}

