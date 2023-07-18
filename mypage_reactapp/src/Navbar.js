import React from "react";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav className="navbar navbar-expand-sm navbar-dark fixed-top">
      <div className="container">
        <Link to="/" className="navbar-brand">
          SIMONA
        </Link>
        <div>
          <ul className="navbar-nav ml-auto">
            <li className="nav-item">
              <a href="/contact" className="nav-link">
                Contact
              </a>
            </li>
            <li className="nav-item">
              <a
                href="https://github.com/SimonAlfons71830"
                className="nav-link"
                target="_blank"
                rel="noopener noreferrer"
              >
                Git
              </a>
            </li>
            <li className="nav-item">
              <a href="/user" className="nav-link">
                Info
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
