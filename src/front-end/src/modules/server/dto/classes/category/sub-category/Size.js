export class Size {
    constructor(dtoObject, fields = ['sizeId', 'maxValue', 'minValue', 'standard']) {
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
