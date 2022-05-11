import {CONFIG} from "../../../../../../configs/config";

export const GetFactory = async () => await fetch(CONFIG.server + CONFIG.GET["factory"]["get-all"])
    .then(response => response.json())
    .then(value => {
        debugger;
        const data = [];
        for (let dtoObject of value[CONFIG.GET["factory"].dto]) {
            data.push(dtoObject);
        }
        return data;
    })
    .catch((error) => console.log(error));
