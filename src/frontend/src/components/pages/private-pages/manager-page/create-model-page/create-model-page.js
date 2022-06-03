import {CreateModel} from "./create-model/create-model";
import './create-model-page.css';

export const CreateModelPage = () => {
    return (
        <div>
            <div className={'create-model-page'}>
                <h1>Create Model</h1>
                <CreateModel/>
            </div>
        </div>
    )
}