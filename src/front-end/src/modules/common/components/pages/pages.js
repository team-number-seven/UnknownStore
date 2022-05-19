import {CONFIG} from "../../../../../../FrontEnd/src/configs/config";
import {PrivatePagesRoutes} from "./private-pages/private-pages-routes";
import {PublicPagesRoutes} from "./public-pages/public-pages-routes";

export const Pages = ({isAuth, userAccessToken, userData}) => {
    return (
        <>
            <PublicPagesRoutes/>
            {userData?.role === CONFIG["user-role"].Owner || userData?.role === CONFIG["user-role"].Manager ?
                <PrivatePagesRoutes/> : <></>
            }
        </>
    );
}
