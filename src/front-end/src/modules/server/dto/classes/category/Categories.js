import {Category} from "./Category";

export class Categories {
    constructor(categoryList) {
        this.value = [];
        for (let category of categoryList) {
            this.value.push(new Category(category));
        }
    }
}



