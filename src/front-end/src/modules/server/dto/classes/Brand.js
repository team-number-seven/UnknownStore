export class Brand {
    constructor(dtoObject, fields = ['brandId', 'title']) {

        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key) {
                    if (key === 'brandId') {
                        this.id = dtoObject[key];
                        break;
                    }
                    this[field] = dtoObject[key];
                    break;
                }
            }
        }
    }
}
