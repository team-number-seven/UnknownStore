import {CONFIG} from "../../../../../../../../FrontEnd/src/configs/config";
import {Categories} from "../../../classes/Categories";

export const GetCategory = async () => await fetch(CONFIG.server + CONFIG.GET["category"]["get-all"])
    .then(response => response.json())
    .then(value => new Categories(value[CONFIG.GET["category"].dto]))
    .catch((error) => console.log(error));
