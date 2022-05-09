import {CONFIG} from "../../../../../../configs/config";
import {DtoTemplateGet} from "../../templates/dto-template-get/dto-template-get";

export const GetSeason = async () => await fetch(CONFIG.server + CONFIG.GET["season"]["get-all"])
    .then(response => response.json())
    .then(value => {
        const data = [];
        for (let dtoObject of value[CONFIG.GET["season"].dto]) {
            data.push(new DtoTemplateGet(dtoObject));
        }
        return data;
    })
    .catch((error) => console.log(error));
