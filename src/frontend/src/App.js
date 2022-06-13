import {AppRoutes} from "./components/app-routes";
import {AuthProvider} from "./hoc/Auth/auth-provider";
import "./App.css";
import "./styles/animations.css";
import {CategoryProvider} from "./hoc/Category/category-provider";
import {FiltersProvider} from "./hoc/Filters/filters-provider";


export const App = () => {

    return (
        <>
            <AuthProvider>
                <CategoryProvider>
                    <FiltersProvider>
                        <AppRoutes/>
                    </FiltersProvider>
                </CategoryProvider>
            </AuthProvider>
        </>
    );
}
