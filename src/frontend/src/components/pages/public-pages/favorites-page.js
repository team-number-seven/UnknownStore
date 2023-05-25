import {useAuth} from "../../../hook/useAuth";
import {useEffect, useState} from "react";
import API from "../../../server/API";
import {CONFIG} from "../../../configs/config";
import {ModelViewBox} from "./models-page/model-view/model-view-box";

export const FavoritesPage = () => {
    const {user, favoritesLoaded} = useAuth();

    const [models, setModels] = useState(null);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        if (!favoritesLoaded) return;
        const getModels = async () => {
            try {
                const favoriteModels = await Promise.all(
                    user.favorites.map(async (f) => {
                        const response = await API.get(CONFIG.GET.model.get, {
                            params: {id: f},
                        });
                        return response.data;
                    })
                );
                setModels(favoriteModels);
            } catch (error) {
                console.log('Error fetching models:', error);
                setModels([]);
            } finally {
                setIsLoading(false);
            }
        };

        if (user && user.favorites && user.favorites.length > 0) {
            getModels();
        } else {
            setModels([]);
            setIsLoading(false);
        }
    }, [user, favoritesLoaded]);

    return (
        <>
            {isLoading && <div>Loading...</div>}
            {!isLoading && !models.length && <div>No Favorites</div>}
            {!isLoading &&
                models &&
                models.map((model, key = 0) => (
                    <ModelViewBox id={model['modelDto'].id} model={model['modelDto']} key={++key}/>
                ))}
        </>
    );
};