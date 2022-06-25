import {createContext, useState} from "react";

export const FiltersContext = createContext(null);
export const FiltersProvider = ({children}) => {
    const [filters, setFilters] = useState({
        title: null,
        minPrice: null,
        maxPrice: null,
        isAvailable: null,
        brandsId: null,
        ageTypesId: null,
        gendersId: null,
        colorsId: null,
        categoriesId: null,
        seasonsId: null,
    });
    const [filtersIsEmpty, setFiltersIsEmpty] = useState(true);


    const changeFilters = (newFilters = {}) => {
        const verifiedFilters = {};
        for (let newFiltersKey in newFilters) {
            if (filters.hasOwnProperty(newFiltersKey)) {
                verifiedFilters[newFiltersKey] = newFilters[newFiltersKey];
            }
        }
        const newVerifiedFilters = Object.assign(filters, verifiedFilters);
        setFilters(newVerifiedFilters);
        setFiltersIsEmpty(false);
    };

    const resetFilters = () => {
        for (let filter in filters) {
            filters[filter] = null;
        }
    };

    const providerValues = {
        filters,
        changeFilters,
        resetFilters,
        filtersIsEmpty
    };

    return (
        <FiltersContext.Provider value={providerValues}>
            {children}
        </FiltersContext.Provider>
    )
}
