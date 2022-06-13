import axios from "axios";
import {CONFIG} from "../configs/config";

export default axios.create({
    baseURL: CONFIG.server,
    headers: {}
});

