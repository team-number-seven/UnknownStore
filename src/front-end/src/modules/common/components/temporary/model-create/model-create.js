import {useForm} from "react-hook-form";
import {GetCategory} from "../../../../server/dto/get/requests/get-category/get-category";
import {PostModel} from "../../../../server/dto/post/requests/post-model/post-model";
import {capitalLetter} from "../../../../utilites/capitalLetter";
import {BrandList} from "./lists/brand-list";
import {ModelFormTemplate} from "./model-form-template";


export const ModelCreate = () => {
    let categories;
    GetCategory().then(value => categories = value);


    const {
        formState: {errors, isValid},
        handleSubmit,
        register,
        reset,
        getValues,
    } = useForm({
            mode: 'all'
        }
    );

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
                <BrandList/>
            </select>
            {errors?.brand && <small className="input-error">{errors?.brand?.message}</small>}


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

            </select>
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
