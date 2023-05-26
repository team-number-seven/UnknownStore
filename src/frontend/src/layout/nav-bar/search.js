import {useFilters} from "../../hook/useFilters";
import {useNavigate} from "react-router-dom";
import {useState} from "react";

export const Search = () => {

    const {filters, changeFilters} = useFilters();
    const navigate = useNavigate();

    const [inputValue, setInputValue] = useState(filters.title ? filters.title : "");



    const onEnterPress = (e) => {
        if (e.code === "Enter") {
            changeFilters({title: e.target.value});

            navigate("models")
        }
    };

    return (
        <div className={'form-field-container'} style={{height: '100%'}}>
            <input type={'text'}
                   value={inputValue}
                   className="form-control"
                   placeholder={'Search...'}
                   onKeyDown={onEnterPress}
                   onChange={e => setInputValue(e.target.value)}
            />
        </div>
    )
}
