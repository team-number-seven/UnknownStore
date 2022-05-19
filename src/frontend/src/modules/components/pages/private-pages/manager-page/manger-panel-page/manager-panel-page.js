import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../../../configs/routes-config";

export const ManagerPanelPage = () => {

    return (
        <>
            <Link to={'../' + ROUTES_CONFIG.private.manager["create-model"]}>
                <button>Create Model</button>
            </Link>
            <Link to={'../' + ROUTES_CONFIG.private.manager["create-factory"]}>
                <button>Create Factory</button>
            </Link>
        </>
    )
}
