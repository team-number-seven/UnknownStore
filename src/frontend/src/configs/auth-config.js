import { WebStorageStateStore } from 'oidc-client';

export const AuthConfig = {
    authority: "https://localhost:1001",
    client_id: "Store react client",
    redirect_uri: "https://localhost:3000/signin-oidc",
    silent_redirect_uri : "https://localhost:3000/silent-renew-oidc",
    response_type: "code",
    scope: "openid profile UnknownStore.WebAPI",
    post_logout_redirect_uri: "https://localhost:3000/signout-oidc",
    userStore:new WebStorageStateStore({store:localStorage}),
};
