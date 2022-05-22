import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../../../configs/routes-config";

export const ManagerPanelPage = () => {

    return (
        <>
            <Link to={'../' + ROUTES_CONFIG.private.manager["create-model"]}>
                <button className={'link'}>Create Model</button>
            </Link>
            <Link to={'../' + ROUTES_CONFIG.private.manager["create-factory"]}>
                <button className={'link'}>Create Factory</button>
            </Link>
        </>
    )
}
