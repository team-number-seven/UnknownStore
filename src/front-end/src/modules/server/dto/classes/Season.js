export class Season {
    constructor(dtoObject, fields = ['seasonId', 'title']) {
        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key) {
                    if (key === 'seasonId') {
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
