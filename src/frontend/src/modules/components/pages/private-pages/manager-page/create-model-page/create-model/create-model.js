import {useState} from "react";
import {CreateModelForm} from "./create-model-form/create-model-form";


const init = async () => {
}


export const CreateModel = () => {
    const [listValues, setListValues] = useState(undefined);
    if (typeof listValues === "undefined") {
        init().then(value => setListValues(value));
    }

    return (
        <>
            {typeof listValues === "undefined" ? <></> : <CreateModelForm listValues={listValues}/>}
        </>
    )
}
