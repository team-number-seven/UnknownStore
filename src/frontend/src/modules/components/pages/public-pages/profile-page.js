import {userNameFromUserData} from "../../../utilites/userNameFromUserData";

export const ProfilePage = ({userData}) => {
    return (
        <>ProfilePage for {userNameFromUserData(userData)}</>
    )
}
