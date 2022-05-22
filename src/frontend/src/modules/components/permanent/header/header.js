import './header.css';

export const Header = ({onSignInClick, onSignOutClick, isAuth}) => {
    return (
        <header>
            <span>UnknownStore</span>
            {!isAuth ?
                <span><button className={'link'} onClick={onSignInClick}>Sign In</button></span>
                : <span><button className={'link'} onClick={onSignOutClick}>Sign Out</button></span>
            }
        </header>
    )
}
