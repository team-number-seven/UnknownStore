export class Gender{
    constructor(dtoObject, fields = ['genderId', 'title']) {

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
