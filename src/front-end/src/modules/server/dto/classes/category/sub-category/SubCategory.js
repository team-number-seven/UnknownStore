import {Gender} from "./Gender";
import {Size} from "./Size";


export class SubCategory {
    constructor(dtoObject, fields = ['ageCategoryId', 'size', 'title']) {
        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key && !Array.isArray(dtoObject[key])) {
                    this[key] = dtoObject[key];
                    break;
                } else {
                    if (key === 'size') {
                        this[key] = new Size(dtoObject[key]);
                    }
                }
            }
        }
    }
}
