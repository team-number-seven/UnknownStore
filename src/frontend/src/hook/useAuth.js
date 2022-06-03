import {useContext} from "react";
import {AuthContext} from "../hoc/Auth/AuthProvider";

export const useAuth =()=>{
    return useContext(AuthContext)
}
