import {useState} from "react";
import {CONFIG} from "../configs/config";
import {useAuth} from "../hook/useAuth";
import API from "../server/API";
import {cutString} from "./utilites/cutString";

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
        user.favorites.push(model.id);
        if (isAuthenticated) {
            API.post(CONFIG.POST.user["add-favorite"],
                {UserId: user.id, ModelId: model.id})
                .then(result => console.log(result))
                .catch(error => console.log(error))
        } else {
            localStorage.setItem("guestFavorites", JSON.stringify(user.favorites));
        }
    }

    const handleModelUnlike = () => {
        user.favorites = user.favorites.filter(favorite => favorite !== model.id);
        if (isAuthenticated) {
            //post delete favourite request
        } else {
            localStorage.setItem("guestFavorites", JSON.stringify(user.favorites));
        }
    }

    return (
        <div className={"model-view-box"} onClick={handleModelView} onMouseEnter={handleShowBoxInfo}
             onMouseLeave={handleHideBoxInfo}>
            <div className={"model-view-image"}>
                <img src={`data:${model.mainImage["contentType"]};base64, ` + model.mainImage["fileContents"]}
                     alt={model.title}/>
            </div>
            <div className={"model-view-box-info"}>

                {!showBoxInfo &&
                    <div className={"model-view-box-header"}>
                        <h2>{cutString(model.title, 12)}</h2>
                        <span className={"model-view-box-price"}>{model.price} $</span>
                    </div>
                }

                {showBoxInfo &&
                    <div className={"model-view-box-hidden scale-down-ver-top"}>
                        <div className={"model-view-box-header"}>
                            <h2>{model.title}</h2>
                            <span className={"model-view-box-price"}>{model.price} $</span>
                        </div>
                        <div className={"model-view-box-body"}>
                            <span className={"model-view-box-brand"} id={model?.brand?.id}>{model?.brand?.title}</span>
                            <span className={"model-view-box-category"}
                                  id={model?.["subCategory"].id}>{model?.["subCategory"].title}</span>

                        </div>
                        <div className={"model-view-box-footer"}>
                            {user?.favorites.includes(model.id) ?
                                <button onClick={handleModelUnlike}>Unlike</button>
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
