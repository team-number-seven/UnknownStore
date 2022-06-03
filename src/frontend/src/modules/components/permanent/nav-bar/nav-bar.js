import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../configs/routes-config";
import {cutUserName} from "../../../utilites/cutUserName";
import {userNameFromUserData} from "../../../utilites/userNameFromUserData";
import './nav-bar.css';

export const NavBar = ({userData, onSearch}) => {


    const handleSearchSubmit = (e) => {
        if (e.code === "Enter") {
            onSearch(e.target.value);
        }
    }

    return (
        <div className={'nav-bar-container'}>
            <div className={'nav-bar'}>
                <div className={'nav-filters'}>
                    <Link className={'link'} to={ROUTES_CONFIG.public.men}>Men</Link>
                    <Link className={'link'} to={ROUTES_CONFIG.public.women}>Women</Link>
                    <Link className={'link'} to={ROUTES_CONFIG.public.kids}>Kids</Link>
                </div>
                <div className={'user-panel'}>
                    <div className={'form-field-container'} style={{height:'100%'}}>
                        <input type={'text'} style={{height: '100%', maxWidth: '7vw', margin: '0'}}
                               className="form-control"
                               onKeyDown={handleSearchSubmit}
                               placeholder={'Search...'}
                        />
                    </div>
                    <span><Link className={'link'} to={ROUTES_CONFIG.public.bag}>Bag</Link></span>

                    <Link className={'link'} to={ROUTES_CONFIG.public.profile}>
                        {userData ? cutUserName(userNameFromUserData(userData), 8) : 'Guest'}
                    </Link>
                </div>
            </div>

        </div>
    )
}

/*userNameFromUserData(userData)*/
