export const TitleList = ({listValues, listPlaceholder}) => {
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>{listPlaceholder}</option>];
    if (typeof listValues === "undefined") return defOption;

    let listWithoutRepeats = [];

    if (Array.isArray(listValues)) {
        listValues.forEach(listItem => {
            if (!listWithoutRepeats.includes(listWithoutRepeats.find((listWithoutRepeatsItem) => listWithoutRepeatsItem.title === listItem.title))) {
                listWithoutRepeats.push(listItem);
            }
        });
    } else {
        for (let listItem in listValues) {
            if (!listWithoutRepeats.includes(listWithoutRepeats.find((listWithoutRepeatsItem) => listWithoutRepeatsItem.title === listItem.title))) {
                listWithoutRepeats.push(listItem);
            }
        }
    }

    const options = listWithoutRepeats.map((listItem) => {
        key++;
        return <option key={key} value={listItem.id}>{listItem.title}</option>
    });

    const allOptions = defOption.concat(options);
    return (allOptions);
}
