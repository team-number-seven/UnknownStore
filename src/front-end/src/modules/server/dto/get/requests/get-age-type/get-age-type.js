import {CONFIG} from "../../../../../../configs/config";
import {AgeType} from "../../../classes/AgeType";

export const GetAgeType = async () => await fetch(CONFIG.server + CONFIG.GET["age-type"]["get-all"])
        .then(response => response.json())
        .then(value => {
            const data = [];
            for (let dtoObject of value[CONFIG.GET["age-type"].dto]) {
                data.push(new AgeType(dtoObject));
            }
            return data;
        })
        .catch((error) => console.log(error));

