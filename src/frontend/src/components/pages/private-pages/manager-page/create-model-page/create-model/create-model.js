import React from "react";
import {CONFIG} from "../../../../../../configs/config";
import API from "../../../../../../server/API";
import {Categories} from "../../../../../../server/dto/classes/Categories";
import {CreateFactoryForModelCreate} from "./create-factory-for-model-create/create-factory-for-model-create";
import {CreateModelForm} from "./create-model-form/create-model-form";


export class CreateModel extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listValues: false
        }

        this.getAllListValues = this.getAllListValues.bind(this);
        this.handleFactoryListRefresh = this.handleFactoryListRefresh.bind(this);
        this.handleModelCreate = this.handleModelCreate.bind(this);
        this.handleShowCreateFactory = this.handleShowCreateFactory.bind(this);
    }

    componentDidMount() {
        this.getAllListValues().then(value => this.setState({listValues: value}));
    }

    async getAllListValues() {
        const allListValues = {}
        await API.get(CONFIG.GET.category["get-all"])
            .then(result => result.data[CONFIG.GET.category.dto])
            .then(value => allListValues.categories = new Categories(value))
            .catch(error => console.log(error));

        await API.get(CONFIG.GET["age-type"]["get-all"])
            .then(result => result.data[CONFIG.GET["age-type"].dto])
            .then(value => allListValues.ageTypes = value)
            .catch(error => console.log(error));

        await API.get(CONFIG.GET.brand["get-all"])
            .then(result => result.data[CONFIG.GET.brand.dto])
            .then(value => allListValues.brands = value)
            .catch(error => console.log(error));

        await API.get(CONFIG.GET.color["get-all"])
            .then(result => result.data[CONFIG.GET.color.dto])
            .then(value => allListValues.colors = value)
            .catch(error => console.log(error));

        await API.get(CONFIG.GET.season["get-all"])
            .then(result => result.data[CONFIG.GET.season.dto])
            .then(value => allListValues.seasons = value)
            .catch(error => console.log(error));

        await API.get(CONFIG.GET.factory["get-all"])
            .then(result => result.data[CONFIG.GET.factory.dto])
            .then(value => allListValues.factories = value)
            .catch(error => console.log(error));

        return allListValues;
    }

    async handleFactoryListRefresh() {
        API.get(CONFIG.GET.factory["get-all"])
            .then(result => result.data[CONFIG.GET.factory.dto])
            .then(value => {
                const updateFactoryList = {factories: value};
                const previousFactoryList = this.state.listValues;
                Object.assign(previousFactoryList, updateFactoryList);
                this.setState({listValues: previousFactoryList});
            })
            .catch(error => console.log(error));
    }

    async handleModelCreate(dataForCreateModel) {
        API.post(CONFIG.POST.model["add-model"], dataForCreateModel)
            .then(result => {
                if (result.status >= 200 && result.status < 300) {
                    alert('Successfully create');
                }
            })
    }

    handleShowCreateFactory() {
        this.setState({showCreateFactory: !this.state.showCreateFactory});
    }


    render() {
        return (
            <>
                {this.state.showCreateFactory &&
                    <CreateFactoryForModelCreate
                        onClose={this.handleShowCreateFactory}
                        onRefresh={this.handleFactoryListRefresh}
                    />
                }
                {this.state.listValues
                    && <CreateModelForm
                        listValues={this.state.listValues}
                        onModelCreate={this.handleModelCreate}
                        showCreateFactory={this.handleShowCreateFactory}
                    />
                }
            </>
        )
    }
}
