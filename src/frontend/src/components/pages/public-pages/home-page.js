import {useEffect} from "react";
import {useFilters} from "../../../hook/useFilters";
import homePageBackground from "../../../assets/home.jpg"

export const HomePage = () => {
    const {resetFilters} = useFilters();
    useEffect(() => {
        resetFilters();
    }, [])
    return (
        <>
            <img src={homePageBackground} className={"home-page"}/>

            <div className={"home-page-text"}>
                <h1 className={"white"}>Unknown Store</h1>

                <h1>Unknown Store</h1>
            </div>
        </>


);
}
