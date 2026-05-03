using Dapper;
using SoundBitesAPI.Models;
using System.Data;

namespace SoundBitesAPI.Repositories
{
    public class CategoriaRepository
    {
        private readonly IDbConnection _db;

        public CategoriaRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
            var sql = @"SELECT id_categoria AS IdCategoria, nombre AS Nombre FROM Categorias";
            return await _db.QueryAsync<Categoria>(sql);
        }

        public async Task<Categoria?> BuscarPorId(int idCategoria)
        {
            var sql = @"SELECT id_categoria AS IdCategoria, nombre AS Nombre FROM Categorias WHERE id_categoria = @IdCategoria";
            return await _db.QueryFirstOrDefaultAsync<Categoria>(sql, new { IdCategoria = idCategoria });
        }

        public async Task<int> GuardarCategoria(Categoria categoria)
        {
            var sql = @"INSERT INTO Categorias (nombre) 
                        VALUES (@Nombre)";
            return await _db.ExecuteAsync(sql, categoria);
        }

        public async Task<int> ActualizarCategoria(Categoria categoria)
        {
            var sql = @"UPDATE Categorias 
                        SET nombre = @Nombre
                        WHERE id_categoria = @IdCategoria";
            return await _db.ExecuteAsync(sql, categoria);
        }

        public async Task<int> EliminarCategoria(int idCategoria)
        {
            var sql = @"DELETE FROM Categorias WHERE id_categoria = @IdCategoria";
            return await _db.ExecuteAsync(sql, new { IdCategoria = idCategoria });
        }
    }
}
