import {useState} from "react";
import {useForm} from "react-hook-form";
import {GetFactory} from "../../../../../server/dto/get/requests/get-factory/get-factory";
import {PostModel} from "../../../../../server/dto/post/requests/post-model/post-model";
import {FactoryCreate} from "../factory-create/factory-create";
import {SizeList} from "../lists/size-list";
import {ModelData} from "../model-data/model-data";
import {TitleList} from "../lists/titile-list";
import {ModelCreateFormValues} from "./model-create-form-values";
import {capitalLetter} from "./utilites/capitalLetter";

export const ModelCreateForm = ({listValues}) => {

    const [showFactoryForm, setShowFactoryForm] = useState(false);
    const [modelData, setModelData] = useState([]);

    const {
        formState: {errors, isValid},
        handleSubmit,
        register,
        watch,
        reset,
        getValues,
    } = useForm({
            mode: 'all'
        }
    );
    const form = ModelCreateFormValues;

    const watchCategoryId = watch(form.categoryId, false);
    const watchGenderId = watch(form.genderId, false);
    const watchAgeId = watch(form.ageTypeId, false);
    const watchSubCategoryId = watch(form.subCategoryId, false);


    const onSubmit = (formData) => {
        let data = new FormData(document.querySelector('#model-create-form'));
        console.log(data);

        PostModel(data).then(ok => {
            if (ok) {
                alert("Success");
            } else alert("Failed");
        });
    }

    const showFactoryFormHandler = () => {
        setShowFactoryForm(!showFactoryForm);
    }

    const onCreateFactoryHandler = () => {
        GetFactory().then(value => listValues.factories = value);
    }

    const onUpdateModelDataHandler = (modelDataPair) => {
        debugger;
        if (modelData.includes(modelDataPair)) {
        } else modelData.push(modelDataPair);
    }


    return (
        <>


            <form id={'model-create-form'}
                  className="container form-group"
                  onSubmit={handleSubmit(onSubmit)}
            >

                <input type={'text'}
                       className="form-control"
                       placeholder={capitalLetter(form.title)}
                       {...register(form.title, {
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
                {errors[form.title] &&
                    <small className="input-error">{errors[form.title]?.message}</small>}

                <input type={'text'}
                       className="form-control"
                       placeholder={capitalLetter(form.description)}
                       {...register(form.description, {
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
                {errors[form.description] &&
                    <small className="input-error">{errors[form.description]?.message}</small>}

                <input type={'text'}
                       className="form-control"
                       placeholder={capitalLetter(form.price)}
                       {...register(form.price, {
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
                {errors[form.price] &&
                    <small className="input-error">{errors[form.price]?.message}</small>}

                <select className="form-control selectpicker"
                        data-live-search="true"
                        data-width="fit"
                        defaultValue={''}
                        {...register(form.categoryId, {
                            required: {
                                value: true,
                                message: 'This field cannot be empty',
                            }
                        })}
                >
                    <TitleList listValues={listValues.categories.getAll()} listPlaceholder={'Choose category'}/>
                </select>
                {errors[form.categoryId] &&
                    <small className="input-error">{errors[form.categoryId]?.message}</small>}


                {watchCategoryId &&
                    <select className="form-control selectpicker"
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(form.genderId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={listValues.categories.getGenders(watchCategoryId)}
                                   listPlaceholder={'Choose gender'}/>
                    </select>
                }
                {errors[form.genderId] &&
                    <small className="input-error">{errors[form.genderId]?.message}</small>}

                {watchGenderId &&
                    <select className="form-control selectpicker"
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(form.ageTypeId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={listValues.ageTypes}
                                   listPlaceholder={'Choose age'}/>
                    </select>
                }
                {errors[form.ageTypeId] &&
                    <small className="input-error">{errors[form.ageTypeId]?.message}</small>}


                {watchAgeId &&
                    <select className="form-control selectpicker"
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(form.subCategoryId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList
                            listValues={listValues.categories.findCategory(watchCategoryId, watchAgeId, watchGenderId).subCategories}
                            listPlaceholder={'Choose subcategory'}/>
                    </select>}
                {errors[form.subCategoryId] &&
                    <small className="input-error">{errors[form.subCategoryId]?.message}</small>}

                {watchSubCategoryId &&
                    <select className="form-control selectpicker"
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(form.brandId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={listValues.brands} listPlaceholder={'Choose brand'}/>
                    </select>}
                {errors[form.brandId] &&
                    <small className="input-error">{errors[form.brandId]?.message}</small>}

                {watchSubCategoryId &&
                    <select className="form-control selectpicker"
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(form.factoryId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={listValues.factories} listPlaceholder={'Choose factory'}/>
                    </select>}
                {errors[form.factoryId] &&
                    <small className="input-error">{errors[form.factoryId]?.message}</small>}


                {watchSubCategoryId &&
                    <select className="form-control selectpicker"
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(form.seasonId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={listValues.seasons} listPlaceholder={'Choose season'}/>
                    </select>}
                {errors[form.seasonId] &&
                    <small className="input-error">{errors[form.seasonId]?.message}</small>}

                {watchSubCategoryId &&
                    <select className="form-control selectpicker"
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register(form.colorId, {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={listValues.colors} listPlaceholder={'Choose color'}/>
                    </select>}
                {errors[form.colorId] &&
                    <small className="input-error">{errors[form.colorId]?.message}</small>}

                {watchSubCategoryId &&
                    <div>
                        <SizeList listValues={listValues.categories.findSize(watchCategoryId, watchAgeId, watchGenderId, watchSubCategoryId)}/>
                    </div>
                }
                {errors[form.description] &&
                    <small className="input-error">{errors[form.description]?.message}</small>}

                <input type={'file'}
                       accept={'image/*'}
                       {...register('Files', {
                           required: {
                               value: true,
                               message: 'You need to upload the main picture',
                           },
                       })}
                />
                {errors?.mainPicture && <small className="input-error">{errors?.mainPicture?.message}</small>}

                <input type={'file'}
                       accept={'image/*'}
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
                {modelData.map((pair, key = 0) => {
                    key++;
                    return <span
                        key={key}>
                        <p>{JSON.stringify(pair).replace('{"', '')
                            .replace('"', '')
                            .replace('"','')
                            .replace('"}', '')
                        }</p>
                    </span>
                })
                }
            </div>
            <ModelData onFillPair={onUpdateModelDataHandler}/>

            {showFactoryForm ?
                <FactoryCreate countries={listValues.countries} onCreate={onCreateFactoryHandler}/> : <></>}
            <button onClick={showFactoryFormHandler}>{'Create factory'}</button>

        </>
    )
}
