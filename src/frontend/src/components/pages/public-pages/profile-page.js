import {Link} from "react-router-dom";
import {CONFIG} from "../../../configs/config";
import {ROUTES_CONFIG} from "../../../configs/routes-config";
import {useAuth} from "../../../hook/useAuth";
import {userNameFromUserData} from "../../utilites/userNameFromUserData";

export const ProfilePage = () => {
    const {user} = useAuth();

    return (
        <div>
            <h1>{userNameFromUserData(user)} profile</h1>
            {(user?.role === CONFIG["user-role"].Owner
                    || user?.role === CONFIG["user-role"].Manager)
                && <Link className={'link'} to={'../' + ROUTES_CONFIG.private.manager["manager"]}>Manager Panel</Link>}
            <Link className={"link"} to={"../" + ROUTES_CONFIG.public.favorites}>My Favorites</Link>
        </div>
    )
}
