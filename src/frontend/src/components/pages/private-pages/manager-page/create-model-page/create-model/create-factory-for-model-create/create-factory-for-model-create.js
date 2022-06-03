import React from "react";
import {CONFIG} from "../../../../../../../configs/config";
import API from "../../../../../../../server/API";
import {CreateFactoryForModelCreateWindow} from "./create-factory-for-model-create-window";
import './create-factory-for-model-create.css'

export class CreateFactoryForModelCreate extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            listValues: false,
        }
        this.getAllListValues = this.getAllListValues.bind(this);
        this.handleFactoryCreate = this.handleFactoryCreate.bind(this);
        this.handleCloseWindow = this.handleCloseWindow.bind(this);
    }

    componentDidMount() {
        this.getAllListValues().then(value => this.setState({listValues: value}))
    }
    componentWillUnmount() {
        debugger;
        this.props.onRefresh();
    }

    async getAllListValues() {
        const allListValues = {};
        await API.get(CONFIG.GET.country["get-all"])
            .then(result => result.data[CONFIG.GET.country.dto])
            .then(value => allListValues.countries = value)
            .catch(error => console.log(error));
        return allListValues;
    }

    handleFactoryCreate(dataForCreateFactory) {
        API.post(CONFIG.POST.factory["add-factory"], dataForCreateFactory)
            .then(result => {
                if (result.status >= 200 && result.status < 300) {
                    alert('Successfully created');
                }
            })
            .catch(error => console.log(error));
    }

    handleCloseWindow() {
        this.props.onClose();
    }

    render() {
        return (
            <div className={'create-factory-for-model-background'}>
                {this.state.listValues
                    && <CreateFactoryForModelCreateWindow
                        createFactory={this.handleFactoryCreate}
                        listValues={this.state.listValues}
                        onClose={this.handleCloseWindow}
                    />
                }
            </div>
        )
    }
}
