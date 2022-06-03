import {CONFIG} from "../../configs/config";
import {PrivatePagesRoutes} from "./private-pages/private-pages-routes";
import {PublicPagesRoutes} from "./public-pages/public-pages-routes";

export const PagesRoutes = ({userData, searchTitle, filter}) => {
    return (
        <>
            <PublicPagesRoutes userData={userData} searchTitle={searchTitle} filter={filter}/>
            {userData?.role === CONFIG["user-role"].Owner || userData?.role === CONFIG["user-role"].Manager ?
                <PrivatePagesRoutes/> : <></>
            }
        </>
    );
}
