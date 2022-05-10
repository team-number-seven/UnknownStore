export class Factory {
    constructor(dtoObject, fields = ['factoryId', 'title', 'address', 'countryId']) {
        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key) {
                    if (key === 'factoryId') {
                        this.id = dtoObject[key];
                        break;
                    }
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
