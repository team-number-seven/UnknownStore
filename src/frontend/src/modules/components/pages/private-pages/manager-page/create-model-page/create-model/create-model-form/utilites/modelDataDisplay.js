export const modelDataDisplay = (modelData = {}) => {
    const divs = [];
    let key = 0;
    debugger;
    for (let pairKey in modelData) {
        key++;
        let div = <span key={key}>
                        <p>
                            {pairKey}:{modelData[pairKey]}
                        </p>
                    </span>;
        divs.push(div);
    }
    return (divs);
}
