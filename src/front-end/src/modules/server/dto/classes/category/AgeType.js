export class AgeType {
    constructor(dtoObject, fields = ['ageTypeId', 'title']) {
        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key) {
                    if (key === 'ageTypeId') {
                        this.id = dtoObject[key];
                        break;
                    }
                    this[key] = dtoObject[key];
                    break;
                }
            }
        }
    }
}
