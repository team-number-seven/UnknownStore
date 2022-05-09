import {CONFIG} from "../../../../../../configs/config";
import {AgeTypeDataTemplate} from "../../../request-data-templates/age-type-data-template/age-type-data-template";

export const GetAgeType = async () => {
    await fetch(CONFIG.server + CONFIG.GET["age-type"]["get-all"])
        .then(response => response.json())
        .then(value => {
            const data = [];
            for (let dtoObject of value[CONFIG.GET["age-type"].dto]) {
                debugger;
                data.push(new AgeTypeDataTemplate(dtoObject));
            }
            return data;
        })
        .catch((error) => console.log(error))
}
