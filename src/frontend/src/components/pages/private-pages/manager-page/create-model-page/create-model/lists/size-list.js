export const SizeList = ({listValues, onSizeChange}) => {
    if (typeof listValues === "undefined") return;
    let iterator = listValues.minValue;
    let key = 0;
    let inputs = [];
    while (iterator <= listValues.maxValue) {
        inputs.push(<div
            style={{display: "flex", justifyContent: "space-between", alignItems: "center", maxWidth: "5.859vw"}} key={key}
        >
            <label className={'text-blue'} style={{maxWidth: "1.953vw"}}>{iterator}</label>
            <input className={'form-control'} style={{maxWidth: "5.5vw"}} type={"number"} id={`size-${iterator}`} onChange={onSizeChange}/>
        </div>)
        iterator++;
        key++;
    }
    return (inputs);
}
