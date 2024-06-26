import {useState} from "react";
import {Link, useNavigate} from "react-router-dom";
import {ROUTES_CONFIG} from "../../configs/routes-config";
import {useAuth} from "../../hook/useAuth";
import {cutString} from "../../components/utilites/cutString";
import {userNameFromUserData} from "../../components/utilites/userNameFromUserData";
import './nav-bar.css';
import "../../components/pages/public-pages/models-page/models-page.css";
import {useCategory} from "../../hook/useCategory";
import {NavBarFilterList} from "./nav-bar-filter-list";
import {Search} from "./search";
import {useFilters} from "../../hook/useFilters";

export const NavBar = ({onSearch}) => {
    const {user} = useAuth();
    const {categoryParams} = useCategory();

    const [displayMen, setDisplayMen] = useState(false);
    const [displayWomen, setDisplayWomen] = useState(false);
    const [displayKids, setDisplayKids] = useState(false);

    const navigate = useNavigate();
    const {
        filters,
        changeFilters,
        resetFilters,
    } = useFilters();

    const handleDisplayMen = (e) => {
        if (e.type === "mouseenter") {
            setDisplayMen(true);
        } else if (e.type === "mouseleave") {
            setDisplayMen(false);
        } else if (e.type === "click") {
            const genderId = categoryParams.genders.find(x => x.title === "Men").id;
            const ageId = categoryParams.ageTypes.find(x => x.title === "Adults").id;
            changeFilters({gendersId: genderId, ageTypesId: ageId});

            navigate("models");
            setDisplayMen(false);
        }
    }
    const handleDisplayMenSecond = (e) => {
        if (e.type === "mouseenter") {
            setDisplayMen(true);
        } else if (e.type === "mouseleave") {
            setDisplayMen(false);
        }
    }

    const handleDisplayWomen = (e) => {
        if (e.type === "mouseenter") {
            setDisplayWomen(true);
        } else if (e.type === "mouseleave") {
            setDisplayWomen(false);
        } else if (e.type === "click") {
            const genderId = categoryParams.genders.find(x => x.title === "Women").id;
            const ageId = categoryParams.ageTypes.find(x => x.title === "Adults").id;

            changeFilters({gendersId: genderId, ageTypesId: ageId});

            navigate("models");
            setDisplayWomen(false);

        }
    }
    const handleDisplayWomenSecond = (e) => {
        if (e.type === "mouseenter") {
            setDisplayWomen(true);
        } else if (e.type === "mouseleave") {
            setDisplayWomen(false);
        }
    }

    const handleDisplayKids = (e) => {
        if (e.type === "mouseenter") {
            setDisplayKids(true);
        } else if (e.type === "mouseleave") {
            setDisplayKids(false);
        } else if (e.type === "click") {
            const ageId = categoryParams.ageTypes.find(x => x.title === "Kids").id;

            changeFilters({ageTypesId: ageId, gendersId: null});

            navigate("models");
            setDisplayKids(false);
        }
    }
    const handleDisplayKidsSecond = (e) => {
        if (e.type === "mouseenter") {
            setDisplayKids(true);
        } else if (e.type === "mouseleave") {
            setDisplayKids(false);
        }
    }


    return (
        <div className={'nav-bar-container'}>
            <div className={'nav-bar'}>
                <div className={'nav-filters'}>
                    <div className={"nav-filter"}>
                        <div className={'link'} onMouseEnter={handleDisplayMen}
                             onMouseLeave={handleDisplayMen}
                             onClick={handleDisplayMen}>
                            <span>Men</span>
                        </div>
                        {(categoryParams && displayMen) &&
                            <div className={"nav-list nav-list-short"}
                                 onMouseEnter={handleDisplayMenSecond}
                                 onMouseLeave={handleDisplayMenSecond}
                                 onClick={handleDisplayMen}>
                                <NavBarFilterList genderTitle={"Men"} ageTitle={"Adults"}/>
                            </div>
                        }
                    </div>
                    <div className={"nav-filter"}>
                        <div className={'link'} onMouseEnter={handleDisplayWomen}
                             onMouseLeave={handleDisplayWomen}
                             onClick={handleDisplayWomen}>
                            <span>Women</span>
                        </div>
                        {(categoryParams && displayWomen) &&
                            <div className={"nav-list nav-list-short"}
                                 onMouseEnter={handleDisplayWomenSecond}
                                 onMouseLeave={handleDisplayWomenSecond}
                                 onClick={handleDisplayWomen}>
                                <NavBarFilterList genderTitle={"Women"} ageTitle={"Adults"}/>
                            </div>
                        }
                    </div>

                    <div className={"nav-filter"}>
                        <div className={'link'} onMouseEnter={handleDisplayKids}
                             onMouseLeave={handleDisplayKids}
                             onClick={handleDisplayKids}>
                            <span>Kids</span>
                        </div>
                        {(categoryParams && displayKids) &&
                            <div className={"nav-list"} onMouseEnter={handleDisplayKidsSecond}
                                 onMouseLeave={handleDisplayKidsSecond}
                                 onClick={handleDisplayKids}>
                                <NavBarFilterList ageTitle={"kids"}/>
                            </div>
                        }


                    </div>
                </div>
                <div className={'user-panel'}>
                    <Search/>
                    <span><Link className={'fake-link'} to={ROUTES_CONFIG.public.favorites}>Favorites</Link></span>

                    <span>
                        <Link className={'fake-link'} to={ROUTES_CONFIG.public.profile}>
                        {user?.id ? cutString(userNameFromUserData(user), 8) : user?.name}
                        </Link>
                    </span>
                </div>
            </div>

        </div>
    )
}
