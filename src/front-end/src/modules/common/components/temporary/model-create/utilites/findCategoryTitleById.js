export const findCategoryTitleById = (categoryIdOfTitle, category = []) => {
    
    for (let c of category) {
        if (c.id === categoryIdOfTitle) {
            return c.title;
        }
    }


}
