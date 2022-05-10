import {Header} from "./modules/common/components/permanent/header/header";
import {GetAgeType} from "./modules/server/dto/get/requests/get-age-type/get-age-type";
import {GetBrand} from "./modules/server/dto/get/requests/get-brand/get-brand";
import {GetCategory} from "./modules/server/dto/get/requests/get-category/get-category";
import {GetColor} from "./modules/server/dto/get/requests/get-color/get-color";
import {GetCountry} from "./modules/server/dto/get/requests/get-country/get-country";
import {GetFactory} from "./modules/server/dto/get/requests/get-factory/get-factory";
import {GetSeason} from "./modules/server/dto/get/requests/get-season/get-season";

export const App = () => {

    GetCategory().then(value => console.log(value));
    return (
        <>
            <Header/>
        </>
    )
}
