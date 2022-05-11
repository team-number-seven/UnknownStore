import {useForm} from "react-hook-form";
import {TitleList} from "./lists/titile-list";

export const ModelCreateForm = ({listValues}) => {
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
        //post
    }


    return (
        <>
            <form id={'model-create-form'}
                  className="container form-group"
                  onSubmit={handleSubmit(onSubmit)}
            >

                <input type={'text'}
                       className="form-control"
                       placeholder={'Title'}
                       {...register('title', {
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
                       placeholder={'Description'}
                       {...register('description', {
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
                {errors?.description && <small className="input-error">{errors?.description?.message}</small>}

                <input type={'text'}
                       className="form-control"
                       placeholder={'Price'}
                       {...register('price', {
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

                <select className="form-control selectpicker"
                        data-live-search="true"
                        data-width="fit"
                        defaultValue={''}
                        {...register('brand', {
                            required: {
                                value: true,
                                message: 'This field cannot be empty',
                            }
                        })}
                >
                    <TitleList listValues={listValues.categories.getAll()} listPlaceholder={'Choose category'}/>
                </select>
                {errors?.brand && <small className="input-error">{errors?.brand?.message}</small>}

                <input type={'file'}
                       accept={'image/*'}
                       multiple
                />

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


                <button className="btn btn-primary"
                        type="submit"
                        disabled={!isValid}
                >
                    Upload
                </button>
            </form>
        </>
    )
}
