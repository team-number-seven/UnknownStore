import {GetBrand} from "../../../../../server/dto/get/requests/get-brand/get-brand";
import {defaultListTemplate} from "./default-list-template";

export const ColorList = () => {
    let colorData;
    GetBrand().then(value => colorData = value);
    return defaultListTemplate(colorData, 'Choose color');
}
