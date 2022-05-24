import {useForm} from "react-hook-form";
import {TitleList} from "../lists/titile-list";


export const CreateFactoryForModelCreateWindow = ({listValues, createFactory, onClose}) => {
    const {
        formState: {errors, isValid},
        handleSubmit,
        register,
        watch
    } = useForm({
            mode: 'all'
        }
    );

    const watchCountryId = watch('countryId', false);

    const onSubmit = (formData) => {
        createFactory(formData);
    }
    const handleOnClose = () => {
        onClose();
    }


    return (
        <div className={'create-factory-for-model-container'}>
            <form id={'create-factory-short-form'}
                  className="container form-group"
                  onSubmit={handleSubmit(onSubmit)}
            >
                <div className={'window-close-header'}>
                    <span className={'link'} onClick={handleOnClose}>Close</span>
                </div>

                <div className={'form-field-container'}>
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
                    <div className={'input-error-container'}>
                        {errors?.title &&
                            <small className="input-error">{errors?.title?.message}</small>
                        }
                    </div>
                </div>

                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register('countryId', {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList listValues={listValues.countries} listPlaceholder={'Choose country'}/>
                    </select>
                    <div className={'input-error-container'}>
                        {errors?.countryId &&
                            <small className="input-error">{errors?.countryId?.message}</small>
                        }
                    </div>


                </div>

                <div className={'form-field-container'}>
                    <select className="form-control selectpicker"
                            disabled={!watchCountryId}
                            data-live-search="true"
                            data-width="fit"
                            defaultValue={''}
                            {...register('cityId', {
                                required: {
                                    value: true,
                                    message: 'This field cannot be empty',
                                }
                            })}
                    >
                        <TitleList
                            listValues={watchCountryId ? listValues.countries.find((country) => country.id === watchCountryId)['cities'] : []}
                            listPlaceholder={'Choose city'}
                        />
                    </select>
                    <div className={'input-error-container'}>
                        {errors?.countryId &&
                            <small className="input-error">
                                {errors?.countryId?.message}
                            </small>
                        }
                    </div>


                </div>

                <div className={'form-field-container'}>
                    <input type={'text'}
                           className="form-control"
                           placeholder={'Address line'}
                           {...register('addressLine', {
                               required: {
                                   value: true,
                                   message: 'This field cannot be empty',
                               },
                               pattern: {
                                   value: /^[a-zA-Z\d\s,'-]*$/,
                                   message: 'Invalid address line',
                               }
                           })}
                    />
                    <div className={'input-error-container'}>
                        {errors?.address &&
                            <small className="input-error">
                                {errors?.address?.message}
                            </small>
                        }
                    </div>

                    <button type="submit"
                            disabled={!isValid}
                    >
                        Create
                    </button>
                </div>

            </form>
        </div>
    )
}
