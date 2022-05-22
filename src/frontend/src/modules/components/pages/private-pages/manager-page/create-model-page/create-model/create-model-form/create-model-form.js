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
    const [modelDataIsNotEmpty, setModelDataIsNotEmpty] = useState(false);
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
        setModelDataIsNotEmpty(true);
    }

    const onSizeChangeHandler = (e) => {
        let sizeObj = {};
        let key = e.target.id.slice(5);
        if (+e.target.value > 0) {
            sizeObj[key] = e.target.value;
            setSizes(Object.assign(sizes, sizeObj));
        } else {
            e.target.value = '';
        }
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

                <div className={'main-info-container'}>
                    <div className={'form-field-container'}>
                        <input type={'text'}
                               className="form-control"
                               autoComplete="off"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.title] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.title]?.message}
                                </small>
                            }
                        </div>
                    </div>

                    <div className={'form-field-container'}>
                        <input type={'text'}
                               className="form-control"
                               autoComplete="off"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.description] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.description]?.message}
                                </small>
                            }
                        </div>
                    </div>

                    <div className={'form-field-container'}>
                        <input type={'text'}
                               className="form-control"
                               autoComplete="off"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.price] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.price]?.message}
                                </small>
                            }
                        </div>
                    </div>


                    <div className={'size-container'}>
                        <div className={'form-field-container'}>
                            {watchSubCategoryId &&
                                <>
                                    Enter sizes values:
                                    <div className={'form-size-list-field-container'}>
                                        <SizeList
                                            listValues={listValues.categories.findSize(watchCategoryId, watchAgeId, watchGenderId, watchSubCategoryId)}
                                            onSizeChange={onSizeChangeHandler}
                                        />
                                    </div>
                                </>
                            }
                            {errors[createModelFormValues.description] &&
                                <small
                                    className="input-error">{errors[createModelFormValues.description]?.message}</small>}
                        </div>
                    </div>

                </div>

                <div className={'info-container'}>
                    <div className={'form-field-container'}>
                        <select className="form-control selectpicker form-select"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.categoryId] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.categoryId]?.message}
                                </small>
                            }
                        </div>

                    </div>

                    <div className={'form-field-container'}>
                        <select className="form-control selectpicker form-select"
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
                            <TitleList
                                listValues={watchCategoryId ? listValues.categories.getGenders(watchCategoryId) : []}
                                listPlaceholder={'Choose gender'}/>
                        </select>
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.genderId] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.genderId]?.message}
                                </small>
                            }
                        </div>
                    </div>

                    <div className={'form-field-container'}>
                        <select className="form-control selectpicker form-select"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.ageTypeId] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.ageTypeId]?.message}
                                </small>
                            }
                        </div>
                    </div>

                    <div className={'form-field-container'}>
                        <select className="form-control selectpicker form-select"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.subCategoryId] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.subCategoryId]?.message}
                                </small>
                            }
                        </div>
                    </div>

                    <div className={'form-field-container'}>
                        <select className="form-control selectpicker form-select"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.brandId] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.brandId]?.message}
                                </small>
                            }
                        </div>
                    </div>


                    <div className={'form-field-container'}>
                        <select className="form-control selectpicker form-select"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.factoryId] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.factoryId]?.message}
                                </small>
                            }
                        </div>

                        <span>
                            No factory?
                            <span className={'link'} onClick={handleShowCreateFactoryWindowChange}>
                                Create one!
                            </span>
                        </span>

                    </div>

                    <div className={'form-field-container'}>
                        <select className="form-control selectpicker form-select"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.seasonId] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.seasonId]?.message}
                                </small>
                            }
                        </div>
                    </div>

                    <div className={'form-field-container'}>
                        <select className="form-control selectpicker form-select"
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
                        <div className={'input-error-container'}>
                            {errors[createModelFormValues.colorId] &&
                                <small className="input-error">
                                    {errors[createModelFormValues.colorId]?.message}
                                </small>
                            }
                        </div>
                    </div>

                </div>

                <div className={'images-container'}>
                    <input type={'file'}
                           accept={'image/*'}
                           {...register(createModelFormValues.mainImage, {
                               required: {
                                   value: true,
                                   message: 'You need to upload the main photo',
                               },
                           })}
                    />
                    <div className={'input-error-container'}>
                        {errors?.mainImage &&
                            <small className="input-error">
                                {errors?.mainImage?.message}
                            </small>
                        }
                    </div>

                    <input type={'file'}
                           accept={'image/*'}
                           multiple
                           {...register(createModelFormValues.images, {
                               required: {
                                   value: true,
                                   message: 'You need to upload at least one additional photo',
                               },
                           })}
                    />
                    <div className={'input-error-container'}>
                        {errors?.images &&
                            <small className="input-error">
                                {errors?.images?.message}
                            </small>
                        }
                    </div>
                </div>

                <button type="submit"
                        disabled={!isValid || !modelDataIsNotEmpty}
                >
                    Upload
                </button>

            </form>

            <div className={'model-data-container'}>
                {modelDataDisplay(modelData)}
                <ModelDataForModelCreate onFillPair={onUpdateModelDataHandler}/>
            </div>

        </div>
    )
}
