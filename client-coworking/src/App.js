import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Espacos from "./components/Espacos";

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Espacos />} />
      </Routes>
    </Router>
  );
};

export default App;
