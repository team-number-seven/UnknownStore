export class Country {
    constructor(dtoObject, fields = ['countryId', 'title']) {
        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key) {
                    if (key === 'countryId') {
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
