import {useForm} from "react-hook-form";

export const ModelDataForModelCreateForm = ({onFill}) => {

    const modelData = {};

    const {
        formState: {errors, isValid},
        handleSubmit,
        register,
    } = useForm({
            mode: 'all'
        }
    );

    const onSubmit = (data) => {
        modelData[data.header] = data.description;
        onFill(modelData);
    }


    return (
        <>
            <form id={'create-factory-short-form'}
                  className="container form-group"
                  onSubmit={handleSubmit(onSubmit)}
            >
                <div>
                    <input type={'text'}
                           className="form-control"
                           placeholder={'Header'}
                           {...register('header', {
                               required: {
                                   value: true,
                                   message: 'This field cannot be empty',
                               },
                               pattern: {
                                   value: /^[a-zA-Z\s]*$/,
                                   message: 'Invalid header',
                               }
                           })}
                    />
                    {errors?.header &&
                        <small className="input-error">{errors?.header?.message}</small>}
                </div>
                <div>
                    <input type={'text'}
                           className="form-control"
                           placeholder={'Description'}
                           {...register('description', {
                               required: {
                                   value: true,
                                   message: 'This field cannot be empty',
                               },
                               pattern: {
                                   value: /^[a-zA-Z\d\s,'-]*$/,
                                   message: 'Invalid description',
                               }
                           })}
                    />
                    {errors?.description &&
                        <small className="input-error">{errors?.description?.message}</small>}
                </div>
                <button type="submit"
                        disabled={!isValid}
                >
                    Add
                </button>

            </form>
        </>
    )
}
