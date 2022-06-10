import {AppRoutes} from "./components/app-routes";
import {AuthProvider} from "./hoc/Auth/auth-provider";
import "./App.css";
import {CategoryProvider} from "./hoc/Category/category-provider";


export const App = () => {

    return (
        <>
            <AuthProvider>
                <CategoryProvider>
                    <AppRoutes/>
                </CategoryProvider>
            </AuthProvider>
        </>
    );
}
