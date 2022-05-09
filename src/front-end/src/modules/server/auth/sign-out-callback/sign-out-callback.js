import {Navigate} from "react-router-dom";

export const SignOutCallback = () => {
    return (
        <Navigate to={'../'} replace={true}/>
    )
}
