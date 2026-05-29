const API = "https://localhost:7117/api/genero";

// LISTAR
export const listarGeneros = async () => {
    const res = await fetch(`${API}/listargeneros`);
    return await res.json();
};

// CREAR
export const crearGenero = async (genero) => {
    const res = await fetch(`${API}/creargenero`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(genero),
    });

    return await res.json();
};

// EDITAR
export const editarGenero = async (id, genero) => {
    const res = await fetch(`${API}/editar/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(genero),
    });

    return await res.json();
};

// ELIMINAR
export const eliminarGenero = async (id) => {
    await fetch(`${API}/eliminar/${id}`, {
        method: "DELETE",
    });
};