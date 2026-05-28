const API_URL = "https://localhost:7117/api";

export const listarCategorias = async () => {
    const response = await fetch(`${API_URL}/categoria/listarcategorias`);
    if (!response.ok) throw new Error("Error al listar categorías");
    return await response.json();
};

export const guardarCategoria = async (categoria) => {
    const response = await fetch(`${API_URL}/categoria/guardarcategoria`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(categoria),
    });
    if (!response.ok) throw new Error("Error al guardar categoría");
    return await response.json();
};

export const actualizarCategoria = async (id, categoria) => {
    const response = await fetch(`${API_URL}/categoria/actualizarcategoria/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(categoria),
    });
    if (!response.ok) throw new Error("Error al actualizar categoría");
    return await response.json();
};

export const eliminarCategoria = async (id) => {
    const response = await fetch(`${API_URL}/categoria/eliminar/${id}`, {
        method: "DELETE",
    });
    if (!response.ok) throw new Error("Error al eliminar categoría");
};

export const buscarCategoria = async (id) => {
    const response = await fetch(`${API_URL}/categoria/buscar/${id}`, {
        method: "GET",
    });
    if (!response.ok) throw new Error("Error al buscar categoría");
};