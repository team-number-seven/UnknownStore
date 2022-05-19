export const modelDataDisplay = (modelData = {}) => {
    const divs = [];
    let key = 0;
    for (let pair in modelData) {
        key++;
        let div = <span key={key}>
                        <p>
                            {
                                JSON.stringify(pair)
                                    .replace('{"', '')
                                    .replace('"', '')
                                    .replace('"', '')
                                    .replace('"}', '')
                            }
                        </p>
                    </span>;
        divs.push(div);
    }
    return (divs);
}
