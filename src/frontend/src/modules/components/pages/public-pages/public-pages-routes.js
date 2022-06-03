import {Route, Routes} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../configs/routes-config";
import {BagPage} from "./bag-page";
import {HomePage} from "./home-page";
import {KidsPage} from "./kids-page";
import {MenPage} from "./men-page";
import {NotFoundPage} from "./not-found-page";
import {ProfilePage} from "./profile-page";
import {WomenPage} from "./women-page";

export const PublicPagesRoutes = ({userData}) => {
    return (
        <Routes>
            <Route path={ROUTES_CONFIG.home} element={<HomePage/>}/>
            <Route path={ROUTES_CONFIG.public.profile} element={<ProfilePage userData={userData}/>}/>

            <Route path={ROUTES_CONFIG.public.kids} element={<KidsPage/>}/>
            <Route path={ROUTES_CONFIG.public.women} element={<WomenPage/>}/>
            <Route path={ROUTES_CONFIG.public.men} element={<MenPage/>}/>
            <Route path={ROUTES_CONFIG.public.bag} element={<BagPage/>}/>
            <Route path={'*'} element={<NotFoundPage/>}/>
        </Routes>
    );
}
