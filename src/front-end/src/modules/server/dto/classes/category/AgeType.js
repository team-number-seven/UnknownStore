export class AgeType {
    constructor(dtoObject, fields = ['ageTypeId', 'title']) {
        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key) {
                    this[key] = dtoObject[key];
                    break;
                }
            }
        }
    }
}
