import {useParams} from "react-router-dom";
import React, {useEffect, useState} from "react";
import API from "../../../../server/API";
import {CONFIG} from "../../../../configs/config";
import "./model.css";
import {Swiper, SwiperSlide} from "swiper/react";

// Import Swiper styles
import "swiper/css";
import "swiper/css/effect-fade";
import "swiper/css/navigation";
import "swiper/css/pagination";

// import required modules
import {EffectFade, Navigation, Pagination} from "swiper";
import {useAuth} from "../../../../hook/useAuth";


const defaultModelState = {
    id: null,
    title: null,
    description: null,
    brand: {id: null, title: null},
    amountOfSize: [{id: null, amount: null, value: null}],
    color: {id: null, title: null, hexCode: null},
    factory: {
        id: null,
        title: null,
        country: null,
        address: {id: null, country: null, addressLine: null, city: {id: null, title: null},},
    },
    images: [{fileContents: null, contentType: null}],
    mainImage: {fileContents: null, contentType: null},
    modelData: {},
    price: null,
    season: {id: null, title: null},
    subCategory: {id: null, size: null, title: null},
}

export const ModelPage = () => {
    const {user, isAuthenticated, refreshUser} = useAuth();
    const [model, setModel] = useState(defaultModelState);

    const [toggleLike, setToggleLike] = useState(false);

    const {id} = useParams();

    useEffect(() => {
        setToggleLike(user?.favorites?.includes(model.id))
    }, [user?.favorites]);

    useEffect(() => {
        API.get(CONFIG.GET.model.get, {params: {id}})
            .then((response) => {
                setModel(response.data["modelDto"]);
            })
            .catch((error) => {
                console.log(error);
            });
    }, [id]);

    const handleModelLike = () => {
        user.favorites?.push(model.id);
        if (isAuthenticated) {
            API.post(CONFIG.POST.user["add-favorite"],
                {UserId: user.id, ModelId: model.id}, {headers: {"Authorization": `Bearer ${user.access_token}`}})
                .then(result => setToggleLike(true))
                .catch(error => refreshUser())
        } else {
            localStorage.setItem("guestFavorites", JSON.stringify(user?.favorites));
        }
    }

    const handleModelUnlike = () => {
        user.favorites = user.favorites.filter(favorite => favorite !== model.id);
        if (isAuthenticated) {
            API.delete(CONFIG.DELETE.user["remove-favorite"],
                {
                    headers: {"Authorization": `Bearer ${user.access_token}`},
                    params: {modelId: model.id}
                })
                .then(() => setToggleLike(false)).catch(error => refreshUser());
        } else {
            localStorage.setItem("guestFavorites", JSON.stringify(user.favorites));
        }
    }


    return (
        <div className={"model-page"}>
            <div className={"model-container"}>
                <div className={"model-image-container"}>
                    <img className={"model-image-background"}
                         src={`data:${model.mainImage.contentType};base64,${model.mainImage.fileContents}`}/>
                    {model.images && model.images.length > 0 && (
                        <Swiper
                            spaceBetween={30}
                            effect={"fade"}
                            navigation={true}
                            pagination={{
                                clickable: true,
                            }}
                            modules={[EffectFade, Navigation, Pagination]}
                            className="mySwiper"
                        >
                            {model.images.map((image, index) => (
                                <SwiperSlide key={index}>
                                    <img className={"model-image"}
                                         src={`data:${image.contentType};base64,${image.fileContents}`}
                                         alt={`Image ${index + 1}`}/>
                                </SwiperSlide>
                            ))}
                        </Swiper>
                    )}
                </div>

                <div className={"model-info"}>
                    <div className="model-info-header">
                        <div className="model-header-left">
                            <h2>{model.title}</h2>
                        </div>

                        <div className="model-header-right">
                            <p>{model.price + " $"}</p>
                            {toggleLike ?
                                <button className={"btn-lighter"} onClick={handleModelUnlike}>Unlike</button>
                                :
                                <button onClick={handleModelLike}>Like</button>
                            }
                        </div>
                    </div>

                    <div className={"model-body"}>
                        <div className={"model-body-left"}>

                            <span>
                                <label>Description: </label><span>{model.description} Lorem ipsum dolor sit amet, consectetur adipisicing elit. Accusantium, animi aperiam aspernatur, consequuntur corporis, dolor ducimus eos maxime mollitia natus nemo quam qui rem soluta unde vel vitae voluptate voluptates!    </span>
                            </span>
                            <span>
                            <label>Subcategory: </label> <span>{model.subCategory.title}</span>
                            </span>
                            <span>
                            <label>Brand: </label><span>{model.brand.title}</span>
                            </span>
                            <span>
                            <label>Season: </label><span>{model.season.title}</span>
                            </span>
                            <span>
                            <label>Factory: </label><span>{model.factory.title}</span>
                            </span>


                            <span>
                            <label>Color:</label>
                            <span>{model.color.title}</span>
                                <span
                                    style={{
                                        display: 'inline-block',
                                        width: '20px',
                                        height: '20px',
                                        backgroundColor: model.color.hexCode,
                                        marginLeft: '5px',
                                        border: '1px solid #000'
                                    }}>
                                </span>
                        </span>

                            <div>
                                <label>Additional information: </label>
                                <ul>
                                    {Object.entries(model.modelData).map(([key, value]) => (
                                        <li key={key}>
                                            {key}: {value}
                                        </li>
                                    ))}
                                </ul>
                            </div>
                        </div>


                        <div className={"model-body-right"}>
                            <label>Sizes: </label>
                            {model.amountOfSize.map((size) => (
                                <span
                                    key={size.id}
                                    style={{opacity: size.amount ? '1' : '0.5'}}
                                ><label>{size.value}: </label><span>{size.amount}</span></span>
                            ))}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};/*{`${size.value}: ${size.amount}`}*/
