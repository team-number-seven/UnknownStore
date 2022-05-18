import {CONFIG} from "../../../../../../../../FrontEnd/src/configs/config";

export const GetAgeType = async () => await fetch(CONFIG.server + CONFIG.GET["age-type"]["get-all"])
        .then(response => response.json())
        .then(value => {
            const data = [];
            for (let dtoObject of value[CONFIG.GET["age-type"].dto]) {
                data.push(dtoObject);
            }
            return data;
        })
        .catch((error) => console.log(error));

