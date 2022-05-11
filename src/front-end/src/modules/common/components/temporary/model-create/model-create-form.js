import {useState} from "react";
import {useForm} from "react-hook-form";
import {Category} from "../../../../server/dto/classes/category/Category";
import {GetAgeType} from "../../../../server/dto/get/requests/get-age-type/get-age-type";
import {GetBrand} from "../../../../server/dto/get/requests/get-brand/get-brand";
import {GetCategory} from "../../../../server/dto/get/requests/get-category/get-category";
import {GetColor} from "../../../../server/dto/get/requests/get-color/get-color";
import {GetCountry} from "../../../../server/dto/get/requests/get-country/get-country";
import {GetFactory} from "../../../../server/dto/get/requests/get-factory/get-factory";
import {GetSeason} from "../../../../server/dto/get/requests/get-season/get-season";
import {PostModel} from "../../../../server/dto/post/requests/post-model/post-model";
import {capitalLetter} from "../../../../utilites/capitalLetter";
import {DefaultList} from "./lists/default-list";
import {ModelFormTemplate} from "./model-form-template";


export const ModelCreateForm = ({brand, color, category, country, factory, ageType, season}) => {

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

    const watchShowColor = watch(ModelFormTemplate.brandId.replace('Id', ''), false);

    const onSubmit = (formData) => {
        PostModel(formData).then();
    }

    return (
        <form id={'short-item-create-form'}
              className="container form-group"
              onSubmit={handleSubmit(onSubmit)}
        >

            <input type={'text'}
                   className="form-control"
                   placeholder={capitalLetter(ModelFormTemplate.title)}
                   {...register(ModelFormTemplate.title, {
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
            {errors?.title && <small className="input-error">{errors?.title?.message}</small>}

            <input type={'text'}
                   className="form-control"
                   placeholder={capitalLetter(ModelFormTemplate.description)}
                   {...register(ModelFormTemplate.description, {
                       required: {
                           value: true,
                           message: 'This field cannot be empty',
                       },
                       pattern: {
                           value: /[^a-zA-Z0-9]/g,
                           message: 'Invalid description',
                       }
                   })}
            />
            {errors?.description && <small className="input-error">{errors?.description?.message}</small>}

            <input type={'text'}
                   className="form-control"
                   placeholder={capitalLetter(ModelFormTemplate.price)}
                   {...register(ModelFormTemplate.price, {
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
            {errors?.price && <small className="input-error">{errors?.price?.message}</small>}


            <select id="brand-list"
                    className="form-control selectpicker"
                    data-live-search="true"
                    data-width="fit"
                    defaultValue={''}
                    {...register(ModelFormTemplate.brandId.replace('Id', ''), {
                        required: {
                            value: true,
                            message: 'This field cannot be empty',
                        }
                    })}
            >
                <DefaultList listData={brand} listPlaceHolder={'Choose brand'}/>
            </select>
            {errors?.brand && <small className="input-error">{errors?.brand?.message}</small>}
            {watchShowColor &&
                <select id="color-list"
                        className="form-control selectpicker"
                        data-live-search="true"
                        data-width="fit"
                        defaultValue={''}
                        {...register(ModelFormTemplate.colorId.replace('Id', ''), {
                            required: {
                                value: true,
                                message: 'This field cannot be empty',
                            }
                        })}
                >
                    <DefaultList listData={color} listPlaceHolder={'Choose color'}/>
                </select>
            }
            {errors?.color && <small className="input-error">{errors?.color?.message}</small>}


            <button className="btn btn-primary"
                    type="submit"
                    disabled={!isValid}
            >
                Upload
            </button>
        </form>
    )
}
