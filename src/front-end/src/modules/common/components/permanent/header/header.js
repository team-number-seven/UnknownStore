
export const Header = ({onSignInClick, onSignOutClick, isAuth}) => {
    return (
        <header>
            header
            {!isAuth ?
                <button onClick={onSignInClick}>Sign In</button>
                : <button onClick={onSignOutClick}>Sign Out</button>
            }
        </header>
    )
}
