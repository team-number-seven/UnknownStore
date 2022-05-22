import {CONFIG} from "../../../configs/config";
import {PrivatePagesRoutes} from "./private-pages/private-pages-routes";
import {PublicPagesRoutes} from "./public-pages/public-pages-routes";

export const Pages = ({userData}) => {
    return (
        <div className={'page-container'}>
            <PublicPagesRoutes userData={userData}/>
            {userData?.role === CONFIG["user-role"].Owner || userData?.role === CONFIG["user-role"].Manager ?
                <PrivatePagesRoutes/> : <></>
            }
        </div>
    );
}
