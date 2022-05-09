import {Header} from "./modules/common/components/permanent/header/header";
import {GetAgeType} from "./modules/server/requests/get/requests/get-age-type/get-age-type";
import {GetBrand} from "./modules/server/requests/get/requests/get-brand/get-brand";

export const App = () => {

    GetBrand().then(value => console.log(value))
    return (
        <>
            <Header/>
        </>
    )
}
