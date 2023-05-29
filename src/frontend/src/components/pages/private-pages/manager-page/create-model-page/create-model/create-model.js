import React, {useState} from "react";
import {CONFIG} from "../../../../../../configs/config";
import {useCategory} from "../../../../../../hook/useCategory";
import API from "../../../../../../server/API";
import {CreateFactoryForModelCreate} from "./create-factory-for-model-create/create-factory-for-model-create";
import {CreateModelForm} from "./create-model-form/create-model-form";


export const CreateModel = () => {
    const [showCreateFactory, setShowCreateFactory] = useState(false);
    const {categoryParams, setCategoryParams} = useCategory();

    const handleFactoryListRefresh = async () => {
        API.get(CONFIG.GET.factory["get-all"])
            .then(result => result.data[CONFIG.GET.factory.dto])
            .then(value => {
                const updateFactoryList = {factories: value};
                const previousFactoryList = categoryParams;
                Object.assign(previousFactoryList, updateFactoryList);
                setCategoryParams(previousFactoryList);
            })
            .catch(error => console.log(error));
    }

    const handleModelCreate = async (dataForCreateModel) => {
        API.post(CONFIG.POST.model["add-model"], dataForCreateModel)
            .then(result => {
                if (result.status >= 200 && result.status < 300) {
                    alert('Successfully create');
                }
            }).catch(error=>alert("Something went wrong"))
    }

    const handleShowCreateFactory = () => {
        setShowCreateFactory(!showCreateFactory);
    }


    return (
        <>
            {showCreateFactory &&
                <CreateFactoryForModelCreate
                    onClose={handleShowCreateFactory}
                    onRefresh={handleFactoryListRefresh}
                />
            }
            {categoryParams
                && <CreateModelForm
                    listValues={categoryParams}
                    onModelCreate={handleModelCreate}
                    showCreateFactory={handleShowCreateFactory}
                />
            }
        </>
    )

}
