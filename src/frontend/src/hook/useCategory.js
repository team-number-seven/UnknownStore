import {useContext} from "react";
import {CategoryContext} from "../hoc/Category/category-provider";

export const useCategory = () => {
    return useContext(CategoryContext);
}
