export class DtoTemplateGet {
    constructor(dtoObject) {
        for (let key in dtoObject) {
            this[key] = dtoObject[key];
        }
    }
}
