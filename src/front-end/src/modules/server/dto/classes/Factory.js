export class Factory {
    constructor(dtoObject, fields = ['factoryId', 'title', 'address', 'countryId']) {
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
