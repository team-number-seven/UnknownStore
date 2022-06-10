import {useParams} from "react-router-dom";

export const ModelPage =()=>{
    const {id}=useParams();
    console.log(useParams());
    return(
        <>
            {id}
        </>
    )
}
