import {CONFIG} from "../../../../../../configs/config";

export const GetCountry = async () => await fetch(CONFIG.server + CONFIG.GET["country"]["get-all"])
    .then(response => response.json())
    .then(value => {
        const data = [];
        for (let dtoObject of value[CONFIG.GET["country"].dto]) {
            data.push(dtoObject);
        }
        return data;
    })
    .catch((error) => console.log(error));
