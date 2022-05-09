import {CONFIG} from "../../../../../../configs/config";
import {DtoTemplateGet} from "../../templates/dto-template-get/dto-template-get";

export const GetAgeType = async () => await fetch(CONFIG.server + CONFIG.GET["age-type"]["get-all"])
        .then(response => response.json())
        .then(value => {
            const data = [];
            for (let dtoObject of value[CONFIG.GET["age-type"].dto]) {
                data.push(new DtoTemplateGet(dtoObject));
            }
            return data;
        })
        .catch((error) => console.log(error));

