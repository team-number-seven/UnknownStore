import {Link} from "react-router-dom";
import {CONFIG} from "../../../../configs/config";
import {ROUTES_CONFIG} from "../../../../configs/routes-config";
import {userNameFromUserData} from "../../../utilites/userNameFromUserData";

export const ProfilePage = ({userData}) => {
    return (
        <div>
            <>ProfilePage for {userNameFromUserData(userData)}</>
            {(userData?.role === CONFIG["user-role"].Owner
                    || userData?.role === CONFIG["user-role"].Manager)
                && <Link to={'../' + ROUTES_CONFIG.private.manager["manager-panel"]}>Manager Panel</Link>}
        </div>
    )
}
