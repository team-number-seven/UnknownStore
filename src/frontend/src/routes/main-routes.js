import {Route, Routes} from "react-router-dom";
import {App} from "../App";


export const MainRoutes = () => {
    return (
        <Routes>
            <Route path={'*'} element={<App/>}/>
        </Routes>
    )
}
