import {Header} from "./modules/common/components/permanent/header/header";
import {GetAgeType} from "./modules/server/requests/get/requests/get-age-type/get-age-type";

export const App = () => {

    GetAgeType();
    return (
        <>
            <Header/>
        </>
    )
}
