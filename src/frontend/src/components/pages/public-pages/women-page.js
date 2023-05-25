import {useEffect, useState} from "react";
import {useCategory} from "../../../hook/useCategory";
import API from "../../../server/API";
import {CONFIG} from "../../../configs/config";
import {FilterBar} from "../../filter-bar/filter-bar";
import {ModelViewBox} from "./models-page/model-view/model-view-box";

export const WomenPage = () => {
    const [models, setModels] = useState(null);
    const [displayModels, setDisplayModels] = useState(false);

    const {categoryParams} = useCategory();


    useEffect(() => {
        if(!categoryParams)return;

        console.log(categoryParams);

        const genderId = categoryParams.genders.find(x => x.title === "Women").id;
        const ageId = categoryParams.ageTypes.find(x => x.title === "Adults").id;

        API.get(CONFIG.GET.model["get-models"], {
            params: {
                GendersId:  genderId,
                AgeTypesId: ageId,
            }
        }).then(response => setModels(response.data["modelDtos"]));
    }, [categoryParams]);
    return (
        <>
            <FilterBar/>
            <div className={"models-page"}>
                {models &&
                    models.map((model, key = 0) =>
                        <ModelViewBox id={model.id} model={model} key={++key}/>
                    )
                }
            </div>
        </>
    );
}