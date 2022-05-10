import {Size} from "./Size";


export class SubCategory {
    constructor(dtoObject, fields = ['subCategoryId', 'size', 'title']) {
        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key && !Array.isArray(dtoObject[key])) {
                    if (key === 'subCategoryId') {
                        this.id = dtoObject[key];
                        break;
                    }
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
