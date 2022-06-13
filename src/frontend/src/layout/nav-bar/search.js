import {useFilters} from "../../hook/useFilters";

export const Search = () => {

    const {changeFilters} = useFilters();

    const onEnterPress = (e) => {
        if (e.code === "Enter") {
            changeFilters({title: e.target.value});
        }
    };

    return (
        <div className={'form-field-container'} style={{height: '100%'}}>
            <input type={'text'} style={{height: '100%', maxWidth: '12vw', margin: '0'}}
                   className="form-control"
                   placeholder={'Search...'}
                   onKeyDown={onEnterPress}
            />
        </div>
    )
}
