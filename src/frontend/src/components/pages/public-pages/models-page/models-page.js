import {useEffect, useState} from "react";
import {useSearchParams} from "react-router-dom";
import {CONFIG} from "../../../../configs/config";
import {useFilters} from "../../../../hook/useFilters";
import API from "../../../../server/API";
import {FilterBar} from "../../../filter-bar/filter-bar";
import {ModelViewBox} from "./model-view/model-view-box";
import "./models-page.css";


export const ModelsPage = () => {
    const [models, setModels] = useState(null);
    const [searchParams, setSearchParams] = useSearchParams();
    const {filters, changeFilters, filtersIsEmpty} = useFilters();


    useEffect(() => {
        if (!filtersIsEmpty) {
            queryBuilder();
        }
        if (searchParams) {
            getFiltersFromQuery();
        }
    }, []);

    useEffect(() => {
        queryBuilder();
        getModels();
    },[searchParams]);

    const getFiltersFromQuery = () => {
        const filtersFromQuery = {};
        searchParams.forEach((value, key) => {
            Object.assign(filtersFromQuery, {[key]: value})
        });
        changeFilters(filtersFromQuery);
    }

    const queryBuilder = () => {
        const queryFilters = {};
        for (let filter in filters) {
            if (filters[filter]) {
                Object.assign(queryFilters, {[filter]: filters[filter]});
            }
        }
        setSearchParams(queryFilters);
    };

    const getModels = () => {
        API.get(CONFIG.GET.model["get-models"], {params: filters})
            .then(result => {
                setModels(result.data["modelDtos"]);
            });
    };

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
