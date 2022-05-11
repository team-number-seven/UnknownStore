export const DefaultList = ({listData = [], listPlaceHolder}) => {

    let key = 0;
    let defOption = [<option value="" key={key++} disabled>{listPlaceHolder}</option>];
    let titleRepeats = [];

    if (listData.length !== 0) {
        const options = listData.map((listItem) => {
            key++;
            if (!titleRepeats.includes(listItem.title)) {
                titleRepeats.push(listItem.title)
                return <option key={key} value={listItem.id ? listItem.id : ''}>{listItem.title}</option>
            } else return <option style={{display:"none"}} key={key} value={listItem.id ? listItem.id : ''}>{listItem.title}</option>
        });
        const allOptions = defOption.concat(options);
        return (allOptions);
    }
    return (defOption)
}

