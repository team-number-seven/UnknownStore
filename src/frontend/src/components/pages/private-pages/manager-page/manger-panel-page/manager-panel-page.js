import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../../configs/routes-config";
import "../../private-pages.css";

export const ManagerPanelPage = () => {

    return (
        <div className={"manager-page"}>
            <h1>Manager Panel</h1>
            <Link to={'../' + ROUTES_CONFIG.private.manager["create-model"]}>
                <button >Create Model</button>
            </Link>
        </div>
    )
}
