import React from 'react';
import ReactDOM from 'react-dom/client';
import 'bootstrap/dist/js/bootstrap.bundle';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'jquery';
import Popper from "popper.js";
import './index.css';
import {BrowserRouter} from "react-router-dom";
import {MainRoutes} from "./modules/routes/main-routes";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <MainRoutes/>
        </BrowserRouter>
    </React.StrictMode>
);
