import {Header} from "./modules/common/components/permanent/header/header";
import {GetCategory} from "./modules/server/dto/get/requests/get-category/get-category";



export const App = () => {
    GetCategory().then(value => console.log(value.findCategory("Shoes", "070258d4-8340-4f83-940f-365d5fd41053", "44340f3b-9bda-4595-be32-3f6260b1df3d").subCategories));
    return (
        <>
            <Header/>
            <ModelCreate/>
        </>
    )
}
