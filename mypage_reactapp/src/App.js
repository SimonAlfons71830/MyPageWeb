import logo from "./logo.svg";
import "./App.css";
import { Home } from "./Home";
import { User } from "./User";
import { BrowserRouter, Route, Routes, Link } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <div className="App container">
        <h3 className="d-flex justify-content-center m-3">
          React JS Frontend Simona
        </h3>
        <nav className="navbar navbar-expand-sm bg-light navbar-datk">
          <u1 className="navbar-nav">
            <li className="nav-item- m-1">
              <Link className="btn btn-light btn-outline-primary" to="/home">
                Home
              </Link>
              <Link className="btn btn-light btn-outline-primary" to="/user">
                User
              </Link>
            </li>
          </u1>
        </nav>
        <Routes>
          <Route path="/home" Component={Home} />
          <Route path="/user" Component={User} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
