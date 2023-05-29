import {Link} from "react-router-dom";
import {useCategory} from "../../hook/useCategory";
import {useFilters} from "../../hook/useFilters";

export const NavBarFilterList = ({genderTitle, ageTitle}) => {
    const {categoryParams} = useCategory();
    const {changeFilters, resetFilters} = useFilters();
    if (!categoryParams) {
        return <></>
    }
    let key = 0;


    const handleCategoryLink = (category = {}) => {
        resetFilters();
        if (category.id) {
            resetFilters();
            changeFilters({categoriesId: category.id, gendersId: category.gender.id, ageTypesId: category.ageType.id});
        }
    }


    let pieceForRender = [];
    if (genderTitle && ageTitle) {

        let currentAge = categoryParams.ageTypes.filter((ageType) => ageType.title.toLowerCase() === ageTitle.toLowerCase())[0];
        let currentGender = categoryParams.genders.filter((gender) => gender.title.toLowerCase() === genderTitle.toLowerCase())[0];
        let categoriesByAge = categoryParams.categories.getByAge(currentAge.id);
        let currentCategories = categoriesByAge.filter((category) => category.gender.id === currentGender.id);


        pieceForRender.push(
            <div className={"nav-list-half nav-list-half-short"} key={++key}>
                <div className={"nav-list-half-header"}>
                    <span>For {genderTitle}</span>
                </div>
                <div className={"nav-list-half-body"} key={++key}>
                    {currentCategories?.map((category) => {
                        return (
                            <div className={"category-list"} key={++key}>
                                <Link to={"models"} key={category.id} replace={true}
                                      className={"link category-link"} onClick={() => handleCategoryLink(category)}>
                                    {category.title}
                                </Link>
                                {category.subCategories
                                    .map((subCategory) => {
                                        return (
                                            <Link to={"models"} key={subCategory.id} replace={true}
                                                  className={"link sub-category-link"}>
                                                {subCategory.title}
                                            </Link>
                                        )
                                    })}
                            </div>
                        )
                    })}
                < /div>


            </div>);
    }

    //KIDS
    if (!genderTitle && ageTitle) {
        let currentAgeType = categoryParams.ageTypes.filter((ageType) => ageType.title.toLowerCase() === ageTitle.toLowerCase())[0];
        let currentCategories = categoryParams.categories.getByAge(currentAgeType.id);

        let boysSearchTerm = "men";
        let boysCategoryGroup = currentCategories.filter((currentCategory) => currentCategory.gender.title.toLowerCase() === boysSearchTerm.toLowerCase());

        let girlsSearchTerm = "women";
        let girlsCategoryGroup = currentCategories.filter((currentCategory) => currentCategory.gender.title.toLowerCase() === girlsSearchTerm.toLowerCase());

        pieceForRender.push(
            <div className={"nav-list-half left-nav-side"} key={++key}>
                <div className={"nav-list-half-header"}>
                    <span>For Boys</span>
                </div>
                <div className={"nav-list-half-body"} key={++key}>
                    {boysCategoryGroup?.map((boysCategory) => {
                        return (
                            <div className={"category-list"} key={++key}>
                                <Link to={"models"} key={boysCategory.id} replace={true}
                                      className={"link category-link"} onClick={() => handleCategoryLink(boysCategory)}>
                                    {boysCategory.title}
                                </Link>
                                {boysCategory.subCategories
                                    .map((boysSubCategory) => {
                                        return (
                                            <Link to={"models"} key={boysSubCategory.id} replace={true}
                                                  className={"link sub-category-link"}>
                                                {boysSubCategory.title}
                                            </Link>
                                        )
                                    })}
                            </div>
                        )
                    })}
                < /div>


            </div>
        );

        pieceForRender.push(
            <div className={"nav-list-half left-nav-side "} key={++key}>
                <div className={"nav-list-half-header"}>
                    <span>For Girls</span>
                </div>
                <div className={"nav-list-half-body"} key={++key}>
                    {girlsCategoryGroup?.map((girlsCategory) => {
                        return (
                            <div className={"category-list"} key={++key}>
                                <Link to={"models"} key={girlsCategory.id} replace={true}
                                      className={"link category-link"} onClick={() => handleCategoryLink(girlsCategory)}>
                                    {girlsCategory.title}
                                </Link>
                                {girlsCategory.subCategories
                                    .map((girlsSubCategory) => {
                                        return (
                                            <Link to={"models"} key={girlsSubCategory.id} replace={true}
                                                  className={"link sub-category-link"}>
                                                {girlsSubCategory.title}
                                            </Link>
                                        )
                                    })}
                            </div>
                        )
                    })}
                </div>
            </div>
        );
    }
    /*if(genderTitle){
    let currentAgeType = categoryParams.gender.filter((ageType) => ageType.title.toLowerCase() === ageTitle.toLowerCase());
    console.log(currentAgeType);
}*/

    return (
        <>{pieceForRender}</>
    )
}
