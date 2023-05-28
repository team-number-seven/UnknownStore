export const modelDataDisplay = (modelData = {}) => {
    const divs = [];
    let key = 0;
    for (let pairKey in modelData) {
        key++;
        let div = <span key={key}>

                            <b>{pairKey}:</b>{modelData[pairKey]}

                    </span>;
        divs.push(div);
    }
    return (divs);
}
