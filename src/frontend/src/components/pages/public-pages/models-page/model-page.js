import {useParams} from "react-router-dom";

export const ModelPage =()=>{
    const {id}=useParams();
    return(
        <>
            {id}
        </>
    )
}
