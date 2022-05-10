import {CONFIG} from "../../../../../../configs/config";
import {CreateModelDto} from "../../templates/create-model-dto";

export const PostModel = async () => {
    const formData = new FormData();
    for (let key in CreateModelDto) {
        formData.append(key, CreateModelDto[key]);
    }
    return await fetch(CONFIG.server + CONFIG.POST.model["add-model"], {
        method: 'POST',
        body: formData,
    })
}
