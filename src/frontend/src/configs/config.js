export const CONFIG = {
    "origin": "https://localhost:3000",
    "server": "https://localhost:2001/store/",
    "content-type-URL8": "application/json; charset=utf-8",
    "requestMode": "cors",
    "auth-routes": {
        "sign-in-callback": "/signin-oidc",
        "silent-sign-in": "/silent-renew-oidc",
        "sign-out-callback": "/signout-oidc",
    },
    "user-role": {
        "User": "User",
        "Manager": "Manager",
        "Owner": "Owner",
    },
    "GET": {
        "age-type": {
            "get-all": "age-type/get-all",
            "dto": "ageTypeDtos"
        },
        "brand": {
            "get-all": "brand/get-all",
            "dto": "brandDtos"
        },
        "category": {
            "get-all": "category/get-all",
            "dto": "categoryDtos"
        },
        "color": {
            "get-all": "color/get-all",
            "dto": "colorDtos"
        },
        "country": {
            "get-all": "country/get-all",
            "dto": "countryDtos"
        },
        "factory": {
            "get-all": "factory/get-all",
            "dto": "factoryDtos"
        },
        "season": {
            "get-all": "season/get-all",
            "dto": "seasonDtos"
        },
        "model": {
            "get-models": "model/get-models",
            "get": "model/get"
        },
        "user": {
            "get-favorites": "user/get-favorites"
        }
    },
    "POST": {
        "model": {
            "add-model": "model/add-model"
        },
        "factory": {
            "add-factory": "factory/add-factory"
        },
        "user": {
            "add-favorite": "user/add-favorite",
            "get-favorites": "user/get-favorites",
        }
    },
    "DELETE":{
        "user":{
            "remove-favorite": "user/remove-favorite",
        }
    }

}
