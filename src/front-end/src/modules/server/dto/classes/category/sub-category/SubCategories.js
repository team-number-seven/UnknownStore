import {SubCategory} from "./SubCategory";

export class SubCategories {
    constructor(subCategoryList) {
        this.value = [];
        for (let subCategory of subCategoryList) {
            this.value.push(new SubCategory(subCategory));
        }
    }
}
