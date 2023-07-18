import React from "react";
import "./App.css";
import { Home } from "./Home";
import { User } from "./User";
import { BrowserRouter, Route, Routes, Link } from "react-router-dom";
import Navbar from "./Navbar"; // Import the Navbar component
import { Contact } from "./Contact";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Navbar /> {/* Include the Navbar component */}
        <h3 className="d-flex justify-content-center m-3">
          React JS Frontend Simona
        </h3>
        <Routes>
          <Route path="/home" Component={Home} />
          <Route path="/user" Component={User} />
          <Route path="/contact" Component={Contact} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
