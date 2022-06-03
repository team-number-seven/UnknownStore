import {ModelDataForModelCreateForm} from "./model-data-for-model-create-form";

export const ModelDataForModelCreate = ({onFillPair}) => {

    const onFillHandler=(modelDataPair)=>{
        onFillPair(modelDataPair);
    }

    return (
        <ModelDataForModelCreateForm onFill={onFillHandler}/>
    )
}
