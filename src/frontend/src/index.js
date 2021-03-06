import React from 'react';
import ReactDOM from 'react-dom/client';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'jquery';
import {BrowserRouter} from "react-router-dom";
import {App} from "./App";


const root = ReactDOM.createRoot(document.getElementById('app'));
root.render(
  <React.StrictMode>
      <BrowserRouter>
          <App/>
      </BrowserRouter>
  </React.StrictMode>
);
