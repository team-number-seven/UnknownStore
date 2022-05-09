export const CONFIG = {
    "origin": "http://localhost:3000",
    "server": "https://localhost:2001/store/",
    "content-type-URL8": "application/json; charset=utf-8",
    "requestMode": "cors",
    "auth-routes": {
        "sign-in-callback": "/signin-oidc",
        "silent-sign-in": "/silent-renew-oidc",
        "sign-out-callback": "/signout-oidc",
    },
    "GET": {
        "age-type": {
            "get-all": "age-type/get-all",
            "dto":"ageTypeDtos"
        },
        "brand": {
            "get-all": "brand/get-all",
            "dto":"brandDtos"
        },
        "category": {
            "get-all": "category/get-all",
            "dto":"categoryDtos"
        },
        "color": {
            "get-all": "color/get-all",
            "dto":"colorDtos"
        },
        "country": {
            "get-all": "country/get-all"
        },
        "factory": {
            "get-all": "factory/get-all"
        },
        "season": {
            "get-all": "season/get-all"
        },
        "home": "home",
    },
    "POST": {
        "model": {
            "add-model": "model/add-model"
        }
    }

}
