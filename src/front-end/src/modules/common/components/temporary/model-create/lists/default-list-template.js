export const DefaultListTemplate = ({getFunction, listPlaceHolder}) => {
    let dataList = [];
    getFunction().then(value => dataList = value);

    let key = 0;
    let defOption = [<option value="" key={key++} disabled>{listPlaceHolder}</option>];
    debugger;
    const options = dataList.map((listItem) => {
        key++;
        return <option key={key} value={listItem.id ? listItem.id : ''}>{listItem.title}</option>
    });
    const allOptions = defOption.concat(options);
    return (allOptions);
}
