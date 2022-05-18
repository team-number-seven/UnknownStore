import React from 'react';
import ReactDOM from 'react-dom/client';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import 'jquery';
import {BrowserRouter} from "react-router-dom";
import {MainRoutes} from "./routes/main-routes";


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
      <BrowserRouter>
          <MainRoutes/>
      </BrowserRouter>
  </React.StrictMode>
);
