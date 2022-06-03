import {Route, Routes} from "react-router-dom";
import {CONFIG} from "../configs/config";
import {ROUTES_CONFIG} from "../configs/routes-config";
import {SignInCallback} from "../hoc/Auth/sign-in-callback";
import {SignOutCallback} from "../hoc/Auth/sign-out-callback";
import {SilentSignIn} from "../hoc/Auth/silent-sign-in";
import {useAuth} from "../hook/useAuth";
import {Layout} from "../layout/layout";
import {CreateFactoryPage} from "./pages/private-pages/manager-page/create-factory-page/create-factory-page";
import {CreateModelPage} from "./pages/private-pages/manager-page/create-model-page/create-model-page";
import {ManagerPanelPage} from "./pages/private-pages/manager-page/manger-panel-page/manager-panel-page";
import {BagPage} from "./pages/public-pages/bag-page";
import {HomePage} from "./pages/public-pages/home-page";
import {ModelPage} from "./pages/public-pages/model-page";
import {NotFoundPage} from "./pages/public-pages/not-found-page";
import {ModelsPage} from "./pages/public-pages/models-page";
import {NewOrderPage} from "./pages/public-pages/new-order-page";
import {ProfilePage} from "./pages/public-pages/profile-page";


function FavouritesPage() {
    return null;
}

function OrdersPage() {
    return null;
}

export const AppRoutes = () => {
    const {user} = useAuth();
    return (
        <Routes>

            {/*AUTH*/}
            <Route path={CONFIG["auth-routes"]["sign-in-callback"]} element={<SignInCallback/>}/>
            <Route path={CONFIG["auth-routes"]["sign-out-callback"]} element={<SignOutCallback/>}/>
            <Route path={CONFIG["auth-routes"]["silent-sign-in"]} element={<SilentSignIn/>}/>

            {/*APP*/}
            <Route path={"/"} element={<Layout/>}>
                <Route index element={<HomePage/>}/>
                <Route path={"*"} element={<NotFoundPage/>}/>

                <Route path={"profile"} element={<ProfilePage/>}>
                    <Route path={"orders"} element={<OrdersPage/>}/>
                    <Route path={"bag"} element={<BagPage/>}/>
                    <Route path={"favourites"} element={<FavouritesPage/>}/>
                </Route>


                <Route path={"models"} element={<ModelsPage/>}>
                    <Route path={"models/:id"} element={<ModelPage/>}/>
                    <Route path={"models/:id/new-order"} element={<NewOrderPage/>}/>
                </Route>


                {(user?.role === CONFIG["user-role"].Owner
                        || user?.role === CONFIG["user-role"].Manager) &&
                    <Route path={"manager"}>
                        <Route index element={<ManagerPanelPage/>}/>
                        <Route path={ROUTES_CONFIG.private.manager["create-model"]} element={<CreateModelPage/>}/>
                        <Route path={ROUTES_CONFIG.private.manager["create-factory"]} element={<CreateFactoryPage/>}/>
                    </Route>
                }}
            </Route>
        </Routes>
    );
}
