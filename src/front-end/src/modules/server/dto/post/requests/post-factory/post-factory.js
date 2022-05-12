import {CONFIG} from "../../../../../../configs/config";

export const PostFactory = async (factoryData) => {
    return await fetch(CONFIG.server + CONFIG.POST.factory["add-factory"], {
        method: "POST",
        headers: {
            'Content-Type': CONFIG["content-type-URL8"]
        },
        body: JSON.stringify(factoryData)
    })
        .then(response => response.ok)
        .catch((e) => console.log(e));
}
