import {FactoryCreateForm} from "./factory-create-form/factory-create-form";


export const FactoryCreate = ({countries, onCreate}) => {
    const onCreateHandler = () => {
        onCreate();
    }
    return (
        <>
            <FactoryCreateForm onCreate={onCreateHandler} countries={countries}/>
        </>
    )
}
