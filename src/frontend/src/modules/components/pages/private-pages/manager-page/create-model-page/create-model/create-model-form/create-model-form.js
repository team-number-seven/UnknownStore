import {useState} from "react";
import {useForm} from "react-hook-form";
import {CreateFactoryForModelCreate} from "../create-factory-for-model-create/create-factory-for-model-create";
import {SizeList} from "../lists/size-list";
import {TitleList} from "../lists/titile-list";
import {ModelDataForModelCreate} from "../model-data-for-model-create/model-data-for-model-create";
import {CreateModelFormValues} from "./create-model-form-values";
import {capitalLetter} from "./utilites/capitalLetter";
import {modelDataDisplay} from "./utilites/modelDataDisplay";

export const CreateModelForm = ({listValues, onModelCreate, refreshFactoryList}) => {
    const [modelData, setModelData] = useState({});
    const [sizes, setSizes] = useState({});
    const [showCreateFactory, setShowCreateFactory] = useState(false);

    const handleShowCreateFactoryWindowChange = () => {
        setShowCreateFactory(!showCreateFactory);
    }
    const handleRefreshFactoryList = () => {
        debugger;
        refreshFactoryList();
    }

    const {
        formState: {errors, isValid},
        handleSubmit,
        register,
        watch,
    } = useForm({
            mode: 'all'
        }
    );
    const createModelFormValues = CreateModelFormValues;

    const watchCategoryId = watch(createModelFormValues.categoryId, false);
    const watchGenderId = watch(createModelFormValues.genderId, false);
    const watchAgeId = watch(createModelFormValues.ageTypeId, false);
    const watchSubCategoryId = watch(createModelFormValues.subCategoryId, false);


    const onUpdateModelDataHandler = (modelDataPair) => {
        Object.assign(modelDataPair, modelData)
        setModelData(modelDataPair);
    }

    const onSizeChangeHandler = (e) => {
        let sizeObj = {};
        let key = e.target.id.slice(5);
        sizeObj[key] = e.target.value;
        setSizes(Object.assign(sizes, sizeObj));
    }

    const onSubmit = (formData) => {
        let data = new FormData(document.querySelector('#create-model-form'));

        data.delete('Files');
        data.append('mainImage', formData.mainImage);
        data.append('images', formData.images);

        let idx = 0;
        for (let key in sizes) {
            data.append(`AmountOfSize[${idx}].Key`, key);
            data.append(`AmountOfSize[${idx}].Value`, sizes[key]);
            idx++;
        }

        idx = 0;
        for (let key in modelData) {
            data.append(`ModelData[${idx}].Key`, key);
            data.append(`ModelData[${idx}].Value`, modelData[key]);
            idx++;
        }

        onModelCreate(data);
    }


    return (

        <div className={'create-model-background-container'}>

            {showCreateFactory && <CreateFactoryForModelCreate onClose={handleShowCreateFactoryWindowChange}
                                                               onRefresh={handleRefreshFactoryList}/>}

            <form id={'create-model-form'}
                  className="container form-group"
                  onSubmit={handleSubmit(onSubmit)}
            >
                <div className={'form-field-container'}>
                    <input type={'text'}
                           className="form-control"
                           placeholder={capitalLetter(createModelFormValues.title)}
                           {...register(createModelFormValues.title, {
                               required: {
                                   value: true,
                                   message: 'This field cannot be empty',
                               },
                               pattern: {
                                   value: /^[a-zA-Z\s]*$/,
                                   message: 'Invalid title',
                               }
                           })}
                    />
                    {errors[createModelFormValues.title] &&
                        <small className="input-error">{errors[createModelFormValues.title]?.message}</small>}
                </div>

                <div className={'form-field-container'}>
                    <input type={'text'}
                           className="form-control"
                           placeholder={capitalLetter(createModelFormValues.description)}
                           {...register(createModelFormValues.description, {
                               required: {
                                   value: true,
                                   message: 'This field cannot be empty',
                               },
                               pattern: {
                                   value: /[^a-zA-Z\d]/g,
                                   message: 'Invalid description',
                               }
                           })}
                    />
                    {errors[createModelFormValues.description] &&
                        <small className="input-error">{errors[createModelFormValues.description]?.message}</small>}
                </div>

                <div className={'form-field-container'}>
                    <input type={'text'}
                           className="form-control"
                           placeholder={capitalLetter(createModelFormValues.price)}
                           {...register(createModelFormValues.price, {
                               required: {
                                   value: true,
                                   message: 'This field cannot be empty',
                               },
                               pattern: {
                                   value: /^(\d{1,3})?(,?\d{3})*(\.\d{2})?$/,
                                   message: 'Invalid price',
                               }
                           })}
                    />
                    {errors[createModelFormValues.price] &&
                        <small className="input-error">{errors[createModelFormValues.price]?.message}</small>}
                </div>

                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(createModelFormValues.categoryId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={listValues.categories ? listValues.categories.getAll() : []}
                                   listPlaceholder={'Choose category'}/>
                    </select>
                    {errors[createModelFormValues.categoryId] &&
                        <small className="input-error">{errors[createModelFormValues.categoryId]?.message}</small>}
                </div>

                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            disabled={!watchCategoryId}
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(createModelFormValues.genderId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={watchCategoryId ? listValues.categories.getGenders(watchCategoryId) : []}
                                   listPlaceholder={'Choose gender'}/>
                    </select>
                    {errors[createModelFormValues.genderId] &&
                        <small className="input-error">{errors[createModelFormValues.genderId]?.message}</small>}
                </div>

                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            disabled={!watchGenderId}
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(createModelFormValues.ageTypeId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={watchGenderId ? listValues.ageTypes : []}
                                   listPlaceholder={'Choose age'}/>
                    </select>

                    {errors[createModelFormValues.ageTypeId] &&
                        <small className="input-error">{errors[createModelFormValues.ageTypeId]?.message}</small>}
                </div>

                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            disabled={!watchAgeId}
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(createModelFormValues.subCategoryId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList
                            listValues={watchAgeId ? listValues.categories.findCategory(watchCategoryId, watchAgeId, watchGenderId).subCategories : []}
                            listPlaceholder={'Choose subcategory'}/>
                    </select>
                    {errors[createModelFormValues.subCategoryId] &&
                        <small className="input-error">{errors[createModelFormValues.subCategoryId]?.message}</small>}
                </div>

                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            disabled={!watchSubCategoryId}
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(createModelFormValues.brandId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={watchSubCategoryId ? listValues.brands : []}
                                   listPlaceholder={'Choose brand'}/>
                    </select>
                    {errors[createModelFormValues.brandId] &&
                        <small className="input-error">{errors[createModelFormValues.brandId]?.message}</small>}
                </div>


                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            disabled={!watchSubCategoryId}
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(createModelFormValues.factoryId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={watchSubCategoryId ? listValues.factories : []}
                                   listPlaceholder={'Choose factory'}/>
                    </select>
                    <span>
                            No factory?
                            <span onClick={handleShowCreateFactoryWindowChange}>
                                Create one!
                            </span>
                    </span>
                    {errors[createModelFormValues.factoryId] &&
                        <small className="input-error">{errors[createModelFormValues.factoryId]?.message}</small>}
                </div>

                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            disabled={!watchSubCategoryId}
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(createModelFormValues.seasonId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={watchSubCategoryId ? listValues.seasons : []}
                                   listPlaceholder={'Choose season'}/>
                    </select>
                    {errors[createModelFormValues.seasonId] &&
                        <small className="input-error">{errors[createModelFormValues.seasonId]?.message}</small>}
                </div>

                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            disabled={!watchSubCategoryId}
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(createModelFormValues.colorId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={watchSubCategoryId ? listValues.colors : []}
                                   listPlaceholder={'Choose color'}/>
                    </select>
                </div>
                {errors[createModelFormValues.colorId] &&
                    <small className="input-error">{errors[createModelFormValues.colorId]?.message}</small>}

                <div className={'form-field-container'}>
                    {watchSubCategoryId &&
                        <div className={'form-size-list-field-container'}>
                            <SizeList
                                listValues={listValues.categories.findSize(watchCategoryId, watchAgeId, watchGenderId, watchSubCategoryId)}
                                onSizeChange={onSizeChangeHandler}
                            />
                        </div>
                    }
                    {errors[createModelFormValues.description] &&
                        <small className="input-error">{errors[createModelFormValues.description]?.message}</small>}
                </div>

                <input type={'file'}
                       accept={'image/*'}
                       {...register(createModelFormValues.mainImage, {
                           required: {
                               value: true,
                               message: 'You need to upload the main picture',
                           },
                       })}
                />
                {errors?.mainPicture && <small className="input-error">{errors?.mainPicture?.message}</small>}

                <input type={'file'}
                       accept={'image/*'}
                       {...register(createModelFormValues.images)}
                       multiple
                />


                <button className="btn btn-primary"
                        type="submit"
                        disabled={!isValid}
                >
                    Upload
                </button>
            </form>


            <div>
                {modelDataDisplay(modelData)}
            </div>
            <ModelDataForModelCreate onFillPair={onUpdateModelDataHandler}/>

        </div>
    )
}
