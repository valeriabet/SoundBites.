const API = "https://localhost:7117/api/plato";

export const obtenerPlatos = async () => {
    const res = await fetch(`${API}/listarplatos`);
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

export const eliminarPlato = async (id) => {
    await fetch(`${API}/eliminar/${id}`, {
        method: "DELETE",
    });
};