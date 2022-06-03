import {Link} from "react-router-dom";
import {CONFIG} from "../../../../configs/config";
import {ROUTES_CONFIG} from "../../../../configs/routes-config";
import {userNameFromUserData} from "../../../utilites/userNameFromUserData";

export const ProfilePage = ({userData}) => {
    return (
        <div className={'page-container'}>
            <h1>{userNameFromUserData(userData)} profile</h1>
            {(userData?.role === CONFIG["user-role"].Owner
                    || userData?.role === CONFIG["user-role"].Manager)
                && <Link className={'link'} to={'../' + ROUTES_CONFIG.private.manager["manager-panel"]}>Manager Panel</Link>}
        </div>
    )
}
