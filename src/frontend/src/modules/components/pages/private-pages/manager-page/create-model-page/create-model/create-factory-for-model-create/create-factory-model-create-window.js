import {useState} from "react";
import {useForm} from "react-hook-form";
import {Navigate} from "react-router-dom";
import {TitleList} from "../lists/titile-list";


export const CreateFactoryModelCreateWindow = ({listValues, createFactory}) => {
    const [onClose, setOnClose] = useState(false);
    const {
        formState: {errors, isValid},
        handleSubmit,
        register,
    } = useForm({
            mode: 'all'
        }
    );

    const onCloseHandler = () => {
    }

    const handleOnKeyPress = (e) => {
        const key = e.key;
        debugger;
        if (key === "Escape") {
            setOnClose(true);
        }
    }


    const onSubmit = (formData) => {
        createFactory(formData);
    }


    return (
        <div className={'create-factory-short-background-container'} onKeyDown={onCloseHandler}>

            {onClose &&
                <Navigate to={'../'} replace={true}/>
            }

            <div className={'create-factory-form-container'}>
                <form id={'create-factory-short-form'}
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
                    {errors?.title &&
                        <small className="input-error">{errors?.title?.message}</small>}

                    <input type={'text'}
                           className="form-control"
                           placeholder={'Address'}
                           {...register('address', {
                               required: {
                                   value: true,
                                   message: 'This field cannot be empty',
                               },
                               pattern: {
                                   value: /^[a-zA-Z0-9\s,'-]*$/,
                                   message: 'Invalid address',
                               }
                           })}
                    />
                    {errors?.address &&
                        <small className="input-error">{errors?.address?.message}</small>}

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
                    {errors?.countryId &&
                        <small className="input-error">{errors?.countryId?.message}</small>}

                    <button className="btn btn-primary"
                            type="submit"
                            disabled={!isValid}
                    >
                        Create
                    </button>

                </form>
            </div>
        </div>
    )
}
