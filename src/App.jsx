import { BrowserRouter, Routes, Route } from "react-router-dom";

import Register from "./Pages/Register";
import Login from "./Pages/Login";
import Reserva from "./Pages/Reserva";
import Home from "./Pages/Home";

import MainLayout from "./Componentes/Layout/MainLayout";

import AdminPlato from "./Pages/Admin/AdminPlato";
import CrearPlato from "./Pages/Admin/CrearPlato";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<Login />} />

                <Route
                    path="/register"
                    element={<Register />}
                />

                <Route
                    path="/"
                    element={<MainLayout />}
                >
                    <Route
                        index
                        element={<Home />}
                    />

                    <Route
                        path="reserva"
                        element={<Reserva />}
                    />

                    <Route
                        path="admin/platos"
                        element={<AdminPlato />}
                    />

                    <Route
                        path="admin/crearplato"
                        element={<CrearPlato />}
                    />
                </Route>
            </Routes>
        </BrowserRouter>
    );
}

export default App;