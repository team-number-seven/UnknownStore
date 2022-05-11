export class Categories {
    constructor(categoryList = []) {
        this.value = [];
        if (categoryList.length !== 0) {
            categoryList.forEach(category => this.value.push(category));
        }
    }

    getAll() {
        return this.value;
    }

    get(categoryId) {
        return this.value.find((category) => category.categoryId === categoryId)
    }

    findTitle(categoryId) {
        for (let category of this.value) {
            if (category.categoryId === categoryId) {
                return category.title;
            }
        }
    }

    findCategory(title, ageTypeId, genderId) {
        for (let category of this.value) {
            if (category.title === title &&
                ageTypeId === category.ageType.ageTypeId &&
                genderId === category.gender.genderId) {
                return category;
            }
        }
    }
}
