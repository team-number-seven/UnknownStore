import {Route, Routes} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../../configs/routes-config";
import {CreateModelPage} from "./manager-page/create-model-page/create-model-page";
import {ManagerPanelPage} from "./manager-page/manger-panel-page/manager-panel-page";

export const PrivatePagesRoutes = () => {
    return (
        <Routes>
            <Route path={ROUTES_CONFIG.private.manager["manager-panel"]} element={<ManagerPanelPage/>}/>
            <Route path={ROUTES_CONFIG.private.manager["create-model"]} element={<CreateModelPage/>}/>
        </Routes>
    );
}
