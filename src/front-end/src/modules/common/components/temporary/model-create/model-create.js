import {useState} from "react";
import {GetAgeType} from "../../../../server/dto/get/requests/get-age-type/get-age-type";
import {GetBrand} from "../../../../server/dto/get/requests/get-brand/get-brand";
import {GetCategory} from "../../../../server/dto/get/requests/get-category/get-category";
import {GetColor} from "../../../../server/dto/get/requests/get-color/get-color";
import {GetCountry} from "../../../../server/dto/get/requests/get-country/get-country";
import {GetFactory} from "../../../../server/dto/get/requests/get-factory/get-factory";
import {GetSeason} from "../../../../server/dto/get/requests/get-season/get-season";
import {ModelCreateForm} from "./model-create-form";

export const ModelCreate = () => {
    const [brand, setBrand] = useState([]);
    const [season, setSeason] = useState([]);
    const [ageType, setAgeType] = useState([]);
    const [country, setCountry] = useState([]);
    const [color, setColor] = useState([]);
    const [factory, setFactory] = useState([]);
    const [category, setCategory] = useState([]);

    if (category.length === 0) {
        GetBrand().then(value => setBrand(value));
        GetSeason().then(value => setSeason(value));
        GetAgeType().then(value => setAgeType(value));
        GetCountry().then(value => setCountry(value));
        GetColor().then(value => setColor(value));
        GetFactory().then(value => setFactory(value));
        GetCategory().then(value => setCategory(value));
    }


    return (
        <ModelCreateForm brand={brand} season={season} ageType={ageType} country={country} color={color}
                         factory={factory} category={category}/>
    )
}
