import {useEffect} from "react";
import {useFilters} from "../../../hook/useFilters";

export const HomePage = () => {
    const {resetFilters} = useFilters();
    useEffect(() => {
        resetFilters();
    }, [])
    return (
        <div>
            <h1>Unknown store</h1>
            {/*<link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
            <div className="example-1">
                <div className="form-group">
                    <label className="label">
                        <i className="material-icons">attach_file</i>
                        <span className="title">Добавить файл</span>
                        <input type="file" style={{display: "none"}}/>
                    </label>
                </div>
            </div>*/}
        </div>
    );
}
