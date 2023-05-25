export const ROUTES_CONFIG = {
    "origin": "http://localhost:3000",
    "index": "*",
    "home": "/",
    "public": {
        "men": "models/men",
        "women": "models/women",
        "kids": "models/kids",
        "profile": "profile",
        "favorites":"favourites",
        "bag": "bag",
    },
    "private": {
        "manager": {
            "manager": "manager",
            "create-model": "create-model",
            "create-factory": "create-factory",
            "create-factory-short": "create-factory-short",
        }
    }
}
