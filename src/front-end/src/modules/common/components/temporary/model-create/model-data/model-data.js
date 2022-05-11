import {ModelDataForm} from "./model-data-form";

export const ModelData = ({onFillPair}) => {

    const onFillHandler=(modelDataPair)=>{
        onFillPair(modelDataPair);
    }

    return (
        <ModelDataForm onFill={onFillHandler}/>
    )
}
