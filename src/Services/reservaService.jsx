const API = "https://localhost:7117/api/reserva";

export const crearReserva = async (reserva) => {
    const res = await fetch(`${API}/guardarreserva`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(reserva),
    });

    if (!res.ok) {
        const text = await res.text();
        throw new Error(text || 'Error al crear reserva');
    }

    return await res.json();
};

export const listarReservas = async () => {
    const res = await fetch(`${API}/listarreservas`);
    return await res.json();
};

export const eliminarReserva = async (id) => {
    const res = await fetch(`${API}/eliminar/${id}`, {
        method: 'DELETE',
    });

    if (!res.ok) {
        const text = await res.text();
        throw new Error(text || 'Error al eliminar reserva');
    }
};
