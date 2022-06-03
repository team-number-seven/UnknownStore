import {useContext} from "react";
import {AuthContext} from "../hoc/Auth/auth-provider";

export const useAuth =()=>{
    return useContext(AuthContext)
}
