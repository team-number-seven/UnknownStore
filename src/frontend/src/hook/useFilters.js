import {useContext} from "react";
import {FiltersContext} from "../hoc/Filters/filters-provider";

export const useFilters = () => {
    return useContext(FiltersContext);
}
