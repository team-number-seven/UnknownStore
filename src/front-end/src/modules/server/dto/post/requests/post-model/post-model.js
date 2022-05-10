import {CONFIG} from "../../../../../../configs/config";

export const PostModel = async (formData) => {

    return await fetch(CONFIG.server + CONFIG.POST.model["add-model"], {
        method: 'POST',
        body: formData,
    })
}
