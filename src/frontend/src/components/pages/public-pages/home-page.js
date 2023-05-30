import {useEffect} from "react";
import {useFilters} from "../../../hook/useFilters";
import homePageBackground from "../../../assets/home-vid.mp4";
import homeWomanImage from "../../../assets/home.jpg";
import homeMenImage from "../../../assets/men.jpg";
import "./../../home-page.css";
import {Link} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../configs/routes-config";


export const HomePage = () => {
    const {resetFilters} = useFilters();
    useEffect(() => {
        resetFilters();
    }, [])
    return (
        <div className={"home-page"}>
            {/* <img src={homePageBackground} className={"home-page"}/>*/}
            <video src={homePageBackground} autoPlay={true} loop={true} muted={true} className={"home-page"}/>

            <div className={"home-page-text"}>
                <h2>Unlock Your Style, Unleash the Unknown</h2>
                <h1>Unknown Store</h1>
            </div>


            <div className="images-block">
                <div className={"image-block"}>
                    <div className={"image-block-text"}>
                        <h1>Explore Women's Style</h1>
                        <h2>Indulge in the latest fashion trends and express your unique style with our diverse range of clothing options for women.</h2>
                    </div>
                    <Link to={ROUTES_CONFIG.public.women}><img src={homeWomanImage} alt="" className="home-big-img"/></Link>
                </div>
                <div className={"image-block"}>
                    <div className={"image-block-text"}>
                        <h1>Discover Men's Fashion</h1>
                        <h2>Explore our stylish collection designed exclusively for men. From timeless classics to the latest trends, find your perfect look with us.</h2>
                    </div>
                    <Link to={ROUTES_CONFIG.public.men}><img src={homeMenImage} alt="" className="home-big-img no-margin"/></Link>
                </div>
            </div>
        </div>


    );
}
