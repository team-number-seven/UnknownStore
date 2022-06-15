import {useState} from "react";
import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../configs/routes-config";
import {useAuth} from "../../hook/useAuth";
import {cutString} from "../../components/utilites/cutString";
import {userNameFromUserData} from "../../components/utilites/userNameFromUserData";
import './nav-bar.css';
import "../../components/pages/public-pages/models-page/models-page.css";
import {useCategory} from "../../hook/useCategory";
import {NavBarFilterList} from "./nav-bar-filter-list";
import {Search} from "./search";

export const NavBar = ({onSearch}) => {
    const {user} = useAuth();
    const {categoryParams} = useCategory();

    const [displayMen, setDisplayMen] = useState(false);
    const [displayWomen, setDisplayWomen] = useState(false);
    const [displayKids, setDisplayKids] = useState(false);

    const handleDisplayMen = (e) => {
        if (e.type === "mouseenter") {
            setDisplayMen(true);
        } else if (e.type === "mouseleave") {
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
                        <Link to={"models"} replace={false} className={'link'} onMouseEnter={handleDisplayMen}
                              onMouseLeave={handleDisplayMen}
                              onClick={handleDisplayMen}>
                            <span>Men</span>
                        </Link>
                        {(categoryParams && displayMen) &&
                            <div className={"nav-list scale-up-ver-top"} onMouseEnter={handleDisplayMenSecond}
                                 onMouseLeave={handleDisplayMenSecond}
                                 onClick={handleDisplayMenSecond}>
                                <NavBarFilterList genderTitle={"Men"} ageTitle={"Adult"}/>
                            </div>
                        }
                    </div>
                    <div className={"nav-filter"}>
                        <Link to={"models"} replace={false} className={'link'} onMouseEnter={handleDisplayWomen}
                              onMouseLeave={handleDisplayWomen}
                              onClick={handleDisplayWomen}>
                            <span>Women</span>
                        </Link>
                        {(categoryParams && displayWomen) &&
                            <div className={"nav-list scale-up-ver-top"} onMouseEnter={handleDisplayWomenSecond}
                                 onMouseLeave={handleDisplayWomenSecond}
                                 onClick={handleDisplayWomenSecond}>
                                <NavBarFilterList genderTitle={"Women"} ageTitle={"Adult"}/>
                            </div>
                        }
                    </div>

                    <div className={"nav-filter"}>
                        <Link to={"models"} replace={false} className={'link'} onMouseEnter={handleDisplayKids}
                              onMouseLeave={handleDisplayKids}
                              onClick={handleDisplayKids}>
                            <span>Kids</span>
                        </Link>
                        {(categoryParams && displayKids) &&
                            <div className={"nav-list scale-up-ver-top"} onMouseEnter={handleDisplayKidsSecond}
                                 onMouseLeave={handleDisplayKidsSecond}
                                 onClick={handleDisplayKidsSecond}>
                                <NavBarFilterList ageTitle={"kids"}/>
                            </div>
                        }


                    </div>
                </div>
                <div className={'user-panel'}>
                    <Search/>
                    <span><Link className={'link'} to={ROUTES_CONFIG.public.bag}>Bag</Link></span>

                    <span>
                        <Link className={'link'} to={ROUTES_CONFIG.public.profile}>
                        {user?.id ? cutString(userNameFromUserData(user), 8) : user?.name}
                        </Link>
                    </span>
                </div>
            </div>

        </div>
    )
}
