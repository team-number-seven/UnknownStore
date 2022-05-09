import {Header} from "./modules/common/components/permanent/header/header";
import {GetAgeType} from "./modules/server/requests/get/requests/get-age-type/get-age-type";
import {GetBrand} from "./modules/server/requests/get/requests/get-brand/get-brand";
import {GetCategory} from "./modules/server/requests/get/requests/get-category/get-category";

export const App = () => {

    GetCategory().then(value => console.log(value))
    return (
        <>
            <Header/>
        </>
    )
}
