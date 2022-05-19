import {useState} from "react";
import {useForm} from "react-hook-form";
import {Link, Outlet} from "react-router-dom";
import {ROUTES_CONFIG} from "../../../../../../../../configs/routes-config";
import {SizeList} from "../lists/size-list";
import {TitleList} from "../lists/titile-list";
import {ModelData} from "../model-fata-for-model-create-form/model-data";
import {CreateModelFormValues} from "./create-model-form-values";
import {capitalLetter} from "./utilites/capitalLetter";
import {modelDataDisplay} from "./utilites/modelDataDisplay";

export const CreateModelForm = ({listValues}) => {
    const [modelData, setModelData] = useState({});
    const [sizes, setSizes] = useState({});

    const {
        formState: {errors, isValid},
        handleSubmit,
        register,
        watch,
    } = useForm({
            mode: 'all'
        }
    );
    const form = CreateModelFormValues;

    const watchCategoryId = watch(form.categoryId, false);
    const watchGenderId = watch(form.genderId, false);
    const watchAgeId = watch(form.ageTypeId, false);
    const watchSubCategoryId = watch(form.subCategoryId, false);


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

        debugger;
        //post model
    }

    const onUpdateModelDataHandler = (modelDataPair) => {
        setModelData(Object.assign(modelData, modelDataPair));
    }

    const onSizeChangeHandler = (e) => {
        let sizeObj = {};
        let key = e.target.id.slice(5);
        sizeObj[key] = e.target.value;
        setSizes(Object.assign(sizes, sizeObj));
    }


    return (
        <div className={'model-create-background-container'}>
            <Outlet/>

            <form id={'create-model-form'}
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
                    <>
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
                        </select>
                        <span>No factory? <Link
                            to={ROUTES_CONFIG.private.manager["create-factory-short"]}>Create one!</Link></span><br/>
                    </>
                }
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
                        <SizeList
                            listValues={listValues.categories.findSize(watchCategoryId, watchAgeId, watchGenderId, watchSubCategoryId)}
                            onSizeChange={onSizeChangeHandler}
                        />
                    </div>
                }
                {errors[form.description] &&
                    <small className="input-error">{errors[form.description]?.message}</small>}

                <input type={'file'}
                       accept={'image/*'}
                       {...register(form.mainImage, {
                           required: {
                               value: true,
                               message: 'You need to upload the main picture',
                           },
                       })}
                />
                {errors?.mainPicture && <small className="input-error">{errors?.mainPicture?.message}</small>}

                <input type={'file'}
                       accept={'image/*'}
                       {...register(form.images)}
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
            <ModelData onFillPair={onUpdateModelDataHandler}/>

        </div>
    )
}
