export class Gender{
    constructor(dtoObject, fields = ['genderId', 'title']) {

        for (let field of fields) {
            for (let key in dtoObject) {
                if (field === key) {
                    if (key === 'genderId') {
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
