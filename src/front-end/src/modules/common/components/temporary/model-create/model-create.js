import {useState} from "react";
import {GetBrand} from "../../../../server/dto/get/requests/get-brand/get-brand";
import {GetCategory} from "../../../../server/dto/get/requests/get-category/get-category";
import {GetColor} from "../../../../server/dto/get/requests/get-color/get-color";
import {GetCountry} from "../../../../server/dto/get/requests/get-country/get-country";
import {GetFactory} from "../../../../server/dto/get/requests/get-factory/get-factory";
import {GetSeason} from "../../../../server/dto/get/requests/get-season/get-season";
import {ModelCreateForm} from "./model-create-form/model-create-form";


const init = async () => {
    const values = {};
    await GetCategory().then(value => values.categories = value);
    await GetBrand().then(value => values.brands = value);
    await GetColor().then(value => values.colors = value);
    await GetCountry().then(value => values.countries = value);
    await GetSeason().then(value => values.seasons = value);
    await GetFactory().then(value => values.factories = value);
    return (values);
}


export const ModelCreate = () => {
    const [listValues, setListValues] = useState(undefined);
    if (typeof listValues === "undefined") {
        init().then(value => setListValues(value));
    }
    return (
        <>
            {typeof listValues === "undefined" ? <></> : <ModelCreateForm listValues={listValues}/>}
        </>
    )
}
