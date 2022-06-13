import {useEffect, useState} from "react";
import {CONFIG} from "../../../../configs/config";
import API from "../../../../server/API";
import {FilterBar} from "../../../filter-bar/filter-bar";
import {ModelViewBox} from "./model-view/model-view-box";
import "./models-page.css";


export const ModelsPage = () => {


    const [models, setModels] = useState(null);

    useEffect(() => {
        API.get(CONFIG.GET.model["get-models"])
            .then(result => {
                setModels(result.data["modelDtos"]);
            });
    }, [])

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
