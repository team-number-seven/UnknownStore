import {Link} from "react-router-dom";
import {useCategory} from "../../hook/useCategory";

export const NavBarFilterList = ({genderTitle, ageTitle}) => {
    const {categoryParams} = useCategory();
    if (!categoryParams) {
        return <></>
    }

    let pieceForRender = [];
    if (genderTitle && ageTitle) {
        let currentAgeType = categoryParams.ageTypes.filter((ageType) => ageType.title.toLowerCase() === ageTitle.toLowerCase())[0];
        let currentGender = categoryParams.genders.filter((gender) => gender.title.toLowerCase() === genderTitle.toLowerCase())[0];
        let currentCategories = categoryParams.categories.getByGender(currentGender.id).filter((category) => category.ageType.title.toLowerCase() === ageTitle.toLowerCase());


        pieceForRender.push(<div className={"age-gender-part"} key={0}>
            <span>For {genderTitle}</span>
            {currentCategories?.map((currentCategory, key = 0) => {
                return (
                    <div className={"age-gender-part-category"} key={++key}>
                        <Link to={"models"} key={currentCategory.id} replace={true}
                              className={"link"}>
                            {currentCategory.title}
                        </Link>
                        {currentCategory.subCategories
                            .map((currentSubCategory) => {
                                return (
                                    <Link to={"models"} key={currentSubCategory.id} replace={true}
                                          className={"link"}>
                                        {currentSubCategory.title}
                                    </Link>
                                )
                            })}
                    </div>
                );
            })}
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
        let key = 0;
        pieceForRender.push(
            <div className={"nav-list-half"} key={++key}>
                <div className={"nav-list-half-header"}>
                    <span>For Boys</span>
                </div>
                <div className={"nav-list-half-body"} key={++key}>
                    {boysCategoryGroup?.map((boysCategory) => {
                        return (
                            <div className={"category-list"} key={++key}>
                                <Link to={"models"} key={boysCategory.id} replace={true}
                                      className={"link category-link"}>
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
            <div className={"nav-list-half"} key={++key}>
                <div className={"nav-list-half-header"}>
                    <span>For Girls</span>
                </div>
                <div className={"nav-list-half-body"} key={++key}>
                    {girlsCategoryGroup?.map((girlsCategory) => {
                        return (
                            <div className={"category-list"} key={++key}>
                                <Link to={"models"} key={girlsCategory.id} replace={true}
                                      className={"link category-link"}>
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
