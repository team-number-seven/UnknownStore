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
        return this.value.find((category) => category.id === categoryId)
    }

    getGenders(categoryId) {
        let value = [];
        for (let category of this.value) {
            if (this.findTitle(category.id) === this.findTitle(categoryId)) {
                value.push(category.gender);
            }
        }
        return value;
    }


    getByGender(genderId) {
        let value = [];
        for (let category of this.value) {
            if (category.gender.id === genderId) {
                value.push(category);
            }
        }
        return value;
    }

    getByAge(ageTypeId) {
        let value = [];
        for (let category of this.value) {
            if (category.ageType.id === ageTypeId) {
                value.push(category);
            }
        }
        return value;
    }

    findTitle(categoryId) {
        for (let category of this.value) {
            if (category.id === categoryId) {
                return category.title;
            }
        }
    }


    findCategory(categoryId, ageTypeId, genderId) {
        for (let category of this.value) {
            if (category.title === this.findTitle(categoryId) &&
                ageTypeId === category.ageType.id &&
                genderId === category.gender.id) {
                return category;
            }
        }
    }

    findSize(categoryId, ageTypeId, genderId, subCategoryId) {
        debugger;
        for (let category of this.value) {
            if (category.title === this.findTitle(categoryId) &&
                ageTypeId === category.ageType.id &&
                genderId === category.gender.id &&
                category.subCategories.includes(category.subCategories.find((subCategory) => subCategory.id === subCategoryId))
            ) {
                return category.subCategories.find((subCategory) => subCategory.id === subCategoryId).size;
            }
        }
    }


}
