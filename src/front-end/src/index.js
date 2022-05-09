import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {BrowserRouter} from "react-router-dom";
import {AuthRoutes} from "./modules/routes/auth-routes";
import {MainRoutes} from "./modules/routes/main-routes";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <MainRoutes/>
        </BrowserRouter>
    </React.StrictMode>
);
