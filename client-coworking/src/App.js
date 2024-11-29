import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Espacos from "./components/Espacos";
import Reservas from "./components/Reservas";
import Auth from "./components/Auth";

const App = () => {
  const [token, setToken] = React.useState(localStorage.getItem("token"));

  if (!token) {
    return <Auth setToken={setToken} />;
  }

  return (
    <Router>
      <Routes>
        <Route path="/" element={<Espacos />} />
        <Route path="/reservas" element={<Reservas />} />
      </Routes>
    </Router>
  );
};

export default App;
