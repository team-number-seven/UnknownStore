import {Route, Routes} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../../../../FrontEnd/src/configs/routes-config";
import {CreateFactoryShort} from "../../temporary/model-create/create-factory-short/create-factory-short";
import {CreateFactoryPage} from "./manager-page/create-factory-page/create-factory-page";
import {CreateModelPage} from "./manager-page/create-model-page/create-model-page";
import {ManagerPanelPage} from "./manager-page/manger-panel-page/manager-panel-page";

export const PrivatePagesRoutes = () => {
    return (
        <Routes>
            <Route path={ROUTES_CONFIG.private.manager["manager-panel"]} element={<ManagerPanelPage/>}/>
            <Route path={ROUTES_CONFIG.private.manager["create-model"]} element={<CreateModelPage/>}>
                <Route path={ROUTES_CONFIG.private.manager["create-factory-short"]} element={<CreateFactoryShort/>}/>
            </Route>

            <Route path={ROUTES_CONFIG.private.manager["create-factory"]} element={<CreateFactoryPage/>}/>
        </Routes>
    );
}
