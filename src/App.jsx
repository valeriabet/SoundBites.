import { BrowserRouter, Routes, Route, useNavigate } from "react-router-dom"
import Register from "./Componentes/Register"
import Login from "./Componentes/Login"

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/register" element={<Register />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App