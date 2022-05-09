export class AgeTypeDataTemplate {
    constructor(dtoObject) {
        debugger;
        for (let key in dtoObject) {
            this[key] = dtoObject[key];
        }
    }
}
