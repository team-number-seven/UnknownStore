export const DefaultList = ({listData = [], listPlaceHolder}) => {
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>{listPlaceHolder}</option>];
    if (listData.length !== 0) {
        const options = listData.map((listItem) => {
            key++;
            return <option key={key} value={listItem.id ? listItem.id : ''}>{listItem.title}</option>
        });
        const allOptions = defOption.concat(options);
        return (allOptions);
    }
    return (defOption)
}
