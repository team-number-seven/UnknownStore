export const SizeList = ({listValues}) => {
    if (typeof listValues === "undefined") return;
    let iterator = listValues.minValue;
    let key = 0;
    let inputs = [];
    while (iterator <= listValues.maxValue) {
        inputs.push(<div style={{display: "flex", justifyContent: "space-between", alignItems: "center", maxWidth:"90px" }} key={key}
        >
            <label style={{maxWidth:"30px"}}>{iterator}</label>
            <input style={{maxWidth:"60px"}} type={"number"}/>
        </div>)
        iterator++;
        key++;
    }
    return (inputs);
}
