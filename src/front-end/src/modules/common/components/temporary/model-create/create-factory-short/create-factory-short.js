import {useState} from "react";
import {GetCountry} from "../../../../../server/dto/get/requests/get-country/get-country";
import {CreateFactoryShortForm} from "./create-factory-short-form/create-factory-short-form";

const init = async () => {
    const values = {};
    await GetCountry().then(value => values.countries = value);
    return values;
}

export const CreateFactoryShort = () => {
    const [listValues, setListValues] = useState(undefined);
    if (typeof listValues === "undefined") {
        init().then(value => setListValues(value));
    }
    return (
        <>
            {typeof listValues === "undefined" ? <></> : <CreateFactoryShortForm countries={listValues.countries}/>}
        </>
    )
}
