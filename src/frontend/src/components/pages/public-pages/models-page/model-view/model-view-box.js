import {useState} from "react";
import {Link} from "react-router-dom";
import {CONFIG} from "../../../../../configs/config";
import {useAuth} from "../../../../../hook/useAuth";
import API from "../../../../../server/API";
import {cutString} from "../../../../utilites/cutString";

export const ModelViewBox = ({model}) => {

    const {user, isAuthenticated} = useAuth();

    const [showBoxInfo, setShowBoxInfo] = useState(false);

    const handleShowBoxInfo = () => {
        setShowBoxInfo(true);
    }
    const handleHideBoxInfo = () => {
        setShowBoxInfo(false);
    }

    const handleModelView = () => {

    }

    const handleModelLike = () => {
        user.favorites?.push(model.id);
        if (isAuthenticated) {
            API.post(CONFIG.POST.user["add-favorite"],
                {UserId: user.id, ModelId: model.id}, {headers: {"Authorization": `Bearer ${user.access_token}`}})
                .then(result => console.log(result))
                .catch(error => console.log(error))
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
                .then().catch(error => console.log(error));
        } else {
            localStorage.setItem("guestFavorites", JSON.stringify(user.favorites));
        }
    }

    return (
        <div className={"model-view-box"} onClick={handleModelView} onMouseEnter={handleShowBoxInfo}
             onMouseLeave={handleHideBoxInfo}>
            <Link to={`/models/${model.id}`}>
                <div className={"model-view-image"}>

                    <img src={`data:${model.mainImage["contentType"]};base64, ` + model.mainImage["fileContents"]}
                         alt={model.title}
                         style={{
                             transition: showBoxInfo && "filter 0.2s ease-out",
                             filter: showBoxInfo && "brightness(70%)",
                             objectFit: showBoxInfo && "cover",
                         }}
                    />
                </div>
            </Link>

            <div className={"model-view-box-info"}>

                {!showBoxInfo &&
                    <div className={"model-view-box-header"}>
                        <h2>{cutString(model.title, 52)}</h2>
                        <span className={"model-view-box-price"}>{model.price} $</span>
                    </div>
                }

                {showBoxInfo &&
                    <div className={"model-view-box-hidden scale-up-ver-bottom"}>
                        <div className={"model-view-box-header"}>
                            <h2>{model.title}</h2>
                            <span className={"model-view-box-price"}>{model.price} $</span>
                        </div>
                        <div className={"model-view-box-body"}>
                            <span className={"model-view-box-category"}
                                  id={model?.["subCategory"].id}>{model?.["subCategory"].title}</span>

                        </div>
                        <div className={"model-view-box-body"}>
                            <span className={"model-view-box-brand"} id={model?.brand?.id}>{model?.brand?.title}</span>
                        </div>
                        <div className={"model-view-box-footer"}>
                            {user?.favorites?.includes(model.id) ?
                                <button className={"btn-lighter"} onClick={handleModelUnlike}>Unlike</button>
                                :
                                <button onClick={handleModelLike}>Like</button>
                            }
                        </div>
                    </div>
                }


                <div className={"model-view-box-footer"}>

                </div>
            </div>
        </div>
    )
}
