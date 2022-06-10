import {createContext, useEffect, useState} from "react";
import {CONFIG} from "../../configs/config";
import API from "../../server/API";
import {Categories} from "../../server/dto/classes/Categories";

export const CategoryContext = createContext(null);
export const CategoryProvider = ({children}) => {
    const [categoryParams, setCategoryParams] = useState(null);

    useEffect(() => {
        getAllCategoryParams().then(result => setCategoryParams(result));
    },[])

    const providerValues = {
        categoryParams,
        setCategoryParams
    };

    return (
        <CategoryContext.Provider value={providerValues}>
            {children}
        </CategoryContext.Provider>
    );
}


const getAllCategoryParams = async () => {
    const allCategoryParams = {};
    await API.get(CONFIG.GET.category["get-all"])
        .then(result => result.data[CONFIG.GET.category.dto])
        .then(value => allCategoryParams.categories = new Categories(value))
        .catch(error => console.log(error));

    await API.get(CONFIG.GET["age-type"]["get-all"])
        .then(result => result.data[CONFIG.GET["age-type"].dto])
        .then(value => allCategoryParams.ageTypes = value)
        .catch(error => console.log(error));

    await API.get(CONFIG.GET.brand["get-all"])
        .then(result => result.data[CONFIG.GET.brand.dto])
        .then(value => allCategoryParams.brands = value)
        .catch(error => console.log(error));

    await API.get(CONFIG.GET.color["get-all"])
        .then(result => result.data[CONFIG.GET.color.dto])
        .then(value => allCategoryParams.colors = value)
        .catch(error => console.log(error));

    await API.get(CONFIG.GET.season["get-all"])
        .then(result => result.data[CONFIG.GET.season.dto])
        .then(value => allCategoryParams.seasons = value)
        .catch(error => console.log(error));

    await API.get(CONFIG.GET.factory["get-all"])
        .then(result => result.data[CONFIG.GET.factory.dto])
        .then(value => allCategoryParams.factories = value)
        .catch(error => console.log(error));

    return allCategoryParams;
}
