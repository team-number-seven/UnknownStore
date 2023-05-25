import {useFilters} from "../../hook/useFilters";
import {useNavigate} from "react-router-dom";

export const Search = () => {

    const {changeFilters} = useFilters();
    const navigate = useNavigate();

    const onEnterPress = (e) => {
        if (e.code === "Enter") {
            changeFilters({title: e.target.value});
            navigate("models")
        }
    };

    return (
        <div className={'form-field-container'} style={{height: '100%'}}>
            <input type={'text'} style={{height: '100%', maxWidth: '7vw', margin: '0'}}
                   className="form-control"
                   placeholder={'Search...'}
                   onKeyDown={onEnterPress}
            />
        </div>
    )
}
