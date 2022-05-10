import {AgeType} from "./AgeType";
import {Gender} from "./sub-category/Gender";
import {SubCategories} from "./sub-category/SubCategories";

export class Category {
    constructor(dtoObject, fields = ['categoryId', 'title', 'subCategories', 'ageType', 'gender']) {
        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key && !Array.isArray(dtoObject[key])) {
                    this[key] = dtoObject[key];
                    break;
                } else {
                    if (key === 'subCategories') {
                        this[key] = new SubCategories(dtoObject[key]);
                    }
                    if (key === 'ageType') {
                        this[key] = new AgeType(dtoObject[key]);
                    }
                    if (key === 'gender') {
                        this[key] = new Gender(dtoObject[key]);
                    }
                }
            }
        }
    }
}
