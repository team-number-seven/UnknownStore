import {Link} from "react-router-dom";
import {CONFIG} from "../../../configs/config";
import {ROUTES_CONFIG} from "../../../configs/routes-config";
import {useAuth} from "../../../hook/useAuth";
import {userNameFromUserData} from "../../utilites/userNameFromUserData";

export const ProfilePage = () => {
    const {user} = useAuth();

    return (
        <div className={"profile-page"}>
            <h1>{userNameFromUserData(user)} profile</h1>
            {(user?.role === CONFIG["user-role"].Owner
                    || user?.role === CONFIG["user-role"].Manager)
                && <Link className={'link'} to={'../' + ROUTES_CONFIG.private.manager["manager"]}>
                    <button>Manager Panel</button>
                </Link>}
            <Link className={"link"} to={"../" + ROUTES_CONFIG.public.favorites}>
                <button>My Favorites</button>
            </Link>
        </div>
    )
}
