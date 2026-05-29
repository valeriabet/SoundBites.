import { useEffect, useState } from "react";
import {
    listarGeneros,
    crearGenero,
    eliminarGenero,
} from "../../Services/generoService";

const AdminGenero = () => {

    const [generos, setGeneros] = useState([]);
    const [nombre, setNombre] = useState("");

    useEffect(() => {
        // Plan:
        // 1. Evitar llamar a `cargarGeneros()` directamente desde el efecto (porque llama a setState
        //    de forma síncrona dentro del efecto).
        // 2. Hacer la petición dentro del propio efecto con una función async.
        // 3. Usar una bandera `mounted` para evitar setState si el componente se desmonta.
        // 4. Manejar errores con try/catch para depuración.
        let mounted = true;

        const fetchGeneros = async () => {
            try {
                const data = await listarGeneros();
                if (mounted) setGeneros(data);
            } catch (error) {
                console.error("Error cargando géneros:", error);
            }
        };

        fetchGeneros();

        return () => {
            mounted = false;
        };
    }, []);

    const guardar = async () => {
        if (!nombre.trim()) return;

        await crearGenero({ nombre });

        setNombre("");
    };

    const eliminar = async (id) => {
        await eliminarGenero(id);
        // Usar actualización funcional para evitar problemas con cierres sobre `generos`
        setGeneros((prev) => prev.filter(g => g.idGenero !== id));
    };

    return (
        <div className="p-6">

            <h1 className="text-2xl font-bold mb-4">
                Administración de Géneros
            </h1>

            {/* CREAR */}
            <div className="flex gap-2 mb-6">
                <input
                    value={nombre}
                    onChange={(e) => setNombre(e.target.value)}
                    placeholder="Nombre del género"
                    className="border p-2 rounded w-full"
                />

                <button
                    onClick={guardar}
                    className="bg-green-500 text-white px-4 rounded"
                >
                    Crear
                </button>
            </div>

            {/* LISTAR */}
            <div className="grid gap-3">
                {generos.map((g) => (
                    <div
                        key={g.idGenero}
                        className="flex justify-between bg-white p-3 rounded shadow"
                    >
                        <span>{g.nombre}</span>

                        <button
                            onClick={() => eliminar(g.idGenero)}
                            className="bg-red-500 text-white px-3 py-1 rounded"
                        >
                            Eliminar
                        </button>
                    </div>
                ))}
            </div>

        </div>
    );
};

export default AdminGenero;