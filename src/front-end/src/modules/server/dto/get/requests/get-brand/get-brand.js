import {CONFIG} from "../../../../../../configs/config";
import {Brand} from "../../../classes/Brand";

export const GetBrand = async () => await fetch(CONFIG.server + CONFIG.GET["brand"]["get-all"])
        .then(response => response.json())
        .then(value => {
            const data = [];
            for (let dtoObject of value[CONFIG.GET.brand.dto]) {
                data.push(new Brand(dtoObject));
            }
            return data;
        })
        .catch((error) => console.log(error));

