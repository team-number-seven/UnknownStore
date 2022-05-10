import {GetBrand} from "../../../../../server/dto/get/requests/get-brand/get-brand";
import {DefaultListTemplate} from "./default-list-template";

export const BrandList = () => {
    return (
        <DefaultListTemplate getFunction={GetBrand} listPlaceHolder={'Choose brand'}/>
    )
}
