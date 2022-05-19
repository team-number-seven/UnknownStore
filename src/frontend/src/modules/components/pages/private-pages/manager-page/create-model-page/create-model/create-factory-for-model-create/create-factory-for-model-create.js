import React from "react";
import {CONFIG} from "../../../../../../../../configs/config";
import API from "../../../../../../../../server/API";
import {Categories} from "../../../../../../../../server/dto/classes/Categories";
import {CreateFactoryModelCreateWindow} from "./create-factory-model-create-window";

export class CreateFactoryForModelCreate extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            listValues: false,
        }
        this.getAllListValues = this.getAllListValues.bind(this);
        this.handleFactoryCreate = this.handleFactoryCreate.bind(this);
    }

    componentDidMount() {
        this.getAllListValues().then(value => this.setState({listValues: value}))
    }

    async getAllListValues() {
        const allListValues = {};
        await API.get(CONFIG.GET.country["get-all"])
            .then(result => result.data[CONFIG.GET.country.dto])
            .then(value => {
                console.log(value)
            })
            .catch(error => console.log(error));
        return allListValues;
    }

    handleFactoryCreate(dataForCreateFactory) {
        //factory-post
        this.props.onFactoryCreate();
    }

    render() {
        return (
            <>
                {this.state.listValues
                    && <CreateFactoryModelCreateWindow
                        createFactory={this.handleFactoryCreate}
                        listValues={this.state.listValues}/>
                }
            </>
        )
    }
}
