export class Size {
    constructor(dtoObject, fields = ['sizeId', 'maxValue', 'minValue', 'standard']) {
        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key) {
                    if (key === 'sizeId') {
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
