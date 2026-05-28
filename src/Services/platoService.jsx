const API = "https://localhost:7117/api/plato";

export const obtenerPlatos = async () => {
    const res = await fetch(`${API}/listarplatos`);
    return await res.json();
};

export const obtenerPlatoPorId = async (id) => {
    const res = await fetch(`${API}/buscar/${id}`);
    if (!res.ok) throw new Error('No se pudo obtener el plato');
    return await res.json();
};

export const crearPlato = async (plato) => {
    const res = await fetch(`${API}/crearplato`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(plato),
    });

    return await res.json();
};

export const actualizarPlato = async (id, plato) => {
    const res = await fetch(`${API}/actualizarplato/${id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(plato),
    });

    if (!res.ok) {
        const text = await res.text();
        throw new Error(text || 'Error al actualizar el plato');
    }

    return await res.json();
};

export const eliminarPlato = async (id) => {
    await fetch(`${API}/eliminar/${id}`, {
        method: "DELETE",
    });
};
