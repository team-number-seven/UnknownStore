import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";
import API from "../../../../server/API";
import {CONFIG} from "../../../../configs/config";
import React from 'react';

import {Swiper, SwiperSlide} from "swiper/react";

// Import Swiper styles
import "swiper/css";
import "swiper/css/effect-fade";
import "swiper/css/navigation";
import "swiper/css/pagination";

// import required modules
import {EffectFade, Navigation, Pagination} from "swiper";


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
    const {id} = useParams();
    const [model, setModel] = useState(defaultModelState);

    useEffect(() => {
        API.get(CONFIG.GET.model.get, {params: {id}})
            .then((response) => {
                console.log(response.data["modelDto"])
                setModel(response.data["modelDto"]);
            })
            .catch((error) => {
                console.log(error);
            });
    }, [id]);


    return (
        <div style={{maxWidth: '600px', margin: '0 auto'}}>
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
                            <img src={`data:${image.contentType};base64,${image.fileContents}`}
                                 alt={`Image ${index + 1}`}/>
                        </SwiperSlide>
                    ))}
                </Swiper>
            )}

            <div>
                <h2>{model.title}</h2>
                <p>{model.description}</p>
                <p>Brand: {model.brand.title}</p>
                <p>
                    Color: {model.color.title}
                    <span
                        style={{
                            display: 'inline-block',
                            width: '20px',
                            height: '20px',
                            backgroundColor: model.color.hexCode,
                            marginLeft: '5px',
                            border: '1px solid #000'
                        }}
                    ></span>
                </p>
                <p>Factory: {model.factory.title}</p>
                <p>Price: {model.price}</p>
                <p>Season: {model.season.title}</p>
                <p>
                    Subcategory: {model.subCategory.title}, Size: {model.subCategory.size}
                </p>
                <div>
                    <p>Model Data:</p>
                    <ul>
                        {Object.entries(model.modelData).map(([key, value]) => (
                            <li key={key}>
                                {key}: {value}
                            </li>
                        ))}
                    </ul>
                </div>
                <div>
                    <p>Amount of Sizes:</p>
                    {model.amountOfSize.map((size) => (
                        <div
                            key={size.id}
                            style={{opacity: size.amount ? '1' : '0.5'}}
                        >{`${size.value}: ${size.amount}`}</div>
                    ))}
                </div>
            </div>
        </div>
    );
};
