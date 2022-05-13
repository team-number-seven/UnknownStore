import {Route, Routes} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../../configs/routes-config";
import {HomePage} from "./home-page/home-page";
import {KidsPage} from "./kids-page/kids-page";
import {MenPage} from "./men-page/men-page";
import {ProfilePage} from "./profile-page/profile-page";

export const PublicPagesRoutes = () => {
    return (
        <Routes>
            <Route path={ROUTES_CONFIG.home} element={<HomePage/>}/>
            <Route path={ROUTES_CONFIG.public.kids} element={<KidsPage/>}/>
            <Route path={ROUTES_CONFIG.public.men} element={<MenPage/>}/>
            <Route path={ROUTES_CONFIG.public.profile} element={<ProfilePage/>}/>
        </Routes>
    );
}
