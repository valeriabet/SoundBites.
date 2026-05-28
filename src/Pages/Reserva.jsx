import { useState } from "react";
import { useLocation, useNavigate, Link } from "react-router-dom";
import { MdMusicNote } from "react-icons/md";

const GENEROS = [
  "Rock",
  "Pop",
  "Jazz",
  "Salsa",
  "Reggaetón",
  "Clásica",
  "Electrónica",
  "Cumbia",
];

const HORAS = [
  "09:00",
  "10:00",
  "11:00",
  "12:00",
  "13:00",
  "14:00",
  "15:00",
  "16:00",
  "17:00",
  "18:00",
  "19:00",
  "20:00",
  "21:00",
];

const Reserva = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const sede = location.state?.sede ?? null;

  const [nombre, setNombre] = useState("");
  const [fecha, setFecha] = useState("");
  const [hora, setHora] = useState("");
  const [genero, setGenero] = useState("");
  const [enviado, setEnviado] = useState(false);
  const [error, setError] = useState("");

  const hoy = new Date().toISOString().split("T")[0];

  const handleSubmit = (e) => {
    e.preventDefault();
    setError("");

    if (!nombre.trim() || !fecha || !hora || !genero) {
      setError("Completa todos los campos y elige un género musical.");
      return;
    }

    const reserva = {
      nombre: nombre.trim(),
      fecha,
      hora,
      genero,
      sede,
    };

    // Conexión con API pendiente
    console.log("Reserva:", reserva);
    setEnviado(true);
  };

  if (enviado) {
    return (
      <div
        className="min-h-full flex-1 flex items-center justify-center px-4 py-12"
        style={{ backgroundColor: "#F7C59F" }}
      >
        <div className="bg-white rounded-2xl shadow-md p-8 w-full max-w-md text-center">
          <div className="bg-orange-400 rounded-full p-4 inline-flex mb-4">
            <MdMusicNote color="white" size={32} />
          </div>
          <h1 className="text-2xl font-bold text-gray-800 mb-2">
            ¡Reserva confirmada!
          </h1>
          <p className="text-gray-500 text-sm mb-6">
            Gracias, {nombre}. Tu voto por <strong>{genero}</strong> quedó
            registrado para el {fecha} a las {hora}
            {sede ? ` en ${sede}` : ""}.
          </p>
          <button
            type="button"
            onClick={() => navigate("/")}
            className="w-full bg-red-900 hover:bg-red-950 text-white font-semibold py-3 rounded-xl transition"
          >
            Volver al inicio
          </button>
        </div>
      </div>
    );
  }

  return (
    <div
      className="min-h-full flex-1 flex items-center justify-center px-4 py-12"
      style={{ backgroundColor: "#F7C59F" }}
    >
      <div className="bg-white rounded-2xl shadow-md p-8 w-full max-w-lg">
        <div className="flex flex-col items-center mb-6">
          <div className="bg-orange-400 rounded-full p-4 mb-3">
            <MdMusicNote color="white" size={32} />
          </div>
          <h1 className="text-2xl font-bold text-gray-800">Hacer reserva</h1>
          <p className="text-gray-400 text-sm text-center">
            {sede
              ? `Sede: ${sede}`
              : "Completa tus datos y vota por tu género favorito"}
          </p>
        </div>

        <form onSubmit={handleSubmit} className="space-y-5">
          <div>
            <label
              htmlFor="nombre"
              className="text-sm font-medium text-gray-700 block mb-1"
            >
              Nombre
            </label>
            <input
              id="nombre"
              type="text"
              placeholder="Tu nombre completo"
              className="w-full border rounded-xl px-3 py-2.5 bg-gray-50 text-sm outline-none focus:ring-2 focus:ring-orange-300"
              value={nombre}
              onChange={(e) => setNombre(e.target.value)}
              required
            />
          </div>

          <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
            <div>
              <label
                htmlFor="fecha"
                className="text-sm font-medium text-gray-700 block mb-1"
              >
                Fecha
              </label>
              <input
                id="fecha"
                type="date"
                min={hoy}
                className="w-full border rounded-xl px-3 py-2.5 bg-gray-50 text-sm outline-none focus:ring-2 focus:ring-orange-300"
                value={fecha}
                onChange={(e) => setFecha(e.target.value)}
                required
              />
            </div>
            <div>
              <label
                htmlFor="hora"
                className="text-sm font-medium text-gray-700 block mb-1"
              >
                Hora
              </label>
              <select
                id="hora"
                className="w-full border rounded-xl px-3 py-2.5 bg-gray-50 text-sm outline-none focus:ring-2 focus:ring-orange-300"
                value={hora}
                onChange={(e) => setHora(e.target.value)}
                required
              >
                <option value="">Selecciona una hora</option>
                {HORAS.map((h) => (
                  <option key={h} value={h}>
                    {h}
                  </option>
                ))}
              </select>
            </div>
          </div>

          <fieldset>
            <legend className="text-sm font-medium text-gray-700 mb-2">
              Vota por un género musical <span className="text-red-800">*</span>
            </legend>
            <div className="grid grid-cols-2 sm:grid-cols-4 gap-2">
              {GENEROS.map((g) => (
                <label
                  key={g}
                  className={`cursor-pointer text-center text-sm font-medium py-2.5 px-2 rounded-xl border-2 transition-all ${
                    genero === g
                      ? "border-red-900 bg-red-50 text-red-900"
                      : "border-gray-200 bg-gray-50 text-gray-600 hover:border-orange-300"
                  }`}
                >
                  <input
                    type="radio"
                    name="genero"
                    value={g}
                    className="sr-only"
                    checked={genero === g}
                    onChange={() => setGenero(g)}
                  />
                  {g}
                </label>
              ))}
            </div>
          </fieldset>

          {error && (
            <p className="text-sm text-red-700 bg-red-50 rounded-lg px-3 py-2">
              {error}
            </p>
          )}

          <button
            type="submit"
            className="w-full bg-red-900 hover:bg-red-950 text-white font-semibold py-3 rounded-xl transition"
          >
            Confirmar reserva
          </button>
        </form>

        <p className="text-center text-sm text-gray-500 mt-4">
          <Link to="/" className="text-orange-500 font-medium hover:underline">
            Cancelar y volver
          </Link>
        </p>
      </div>
    </div>
  );
};

export default Reserva;
