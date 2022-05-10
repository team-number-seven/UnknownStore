import {CONFIG} from "../../../../../../configs/config";
import {Color} from "../../../classes/Color";

export const GetColor = async () => await fetch(CONFIG.server + CONFIG.GET["color"]["get-all"])
    .then(response => response.json())
    .then(value => {
        const data = [];
        for (let dtoObject of value[CONFIG.GET["color"].dto]) {
            data.push(new Color(dtoObject));
        }
        return data;
    })
    .catch((error) => console.log(error));
