import React from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEnvelope, faCameraRetro } from "@fortawesome/free-solid-svg-icons";
//import logoImage from "./logo1.png";

const navLinks = [
  {
    title: "DOMOV",
    path: "/",
  },
  {
    title: "KONTAKT",
    path: "/contact",
  },
  {
    title: "INFO",
    path: "/info",
  },
];

export default function Navigation() {
  return (
    <nav className="site-navigation">
      <div>
        <ul>
          {navLinks.map((link, index) => (
            <li key={index}>
              <Link to={link.path}>{link.title}</Link>
            </li>
          ))}
        </ul>
      </div>
      <div className="logo-container">
        {/* <img src={logoImage} alt="Logo" /> */}
        <span>LegalTech Diaries</span>
      </div>
      <div className="transfer-links">
        <a
          href="https://www.instagram.com/simonaskombarova"
          target="_blank"
          rel="noopener noreferrer"
        >
          <FontAwesomeIcon icon={faCameraRetro} className="icon" />
        </a>
        <a href="mailto:skombarova.simona@gmail.com">
          <FontAwesomeIcon icon={faEnvelope} className="icon" />
        </a>
      </div>
    </nav>
  );
}
