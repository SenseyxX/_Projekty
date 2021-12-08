import axios from "axios";
import vm from "@/main";
import store from "@/store";
import { AuthenticationResultStorageKey } from "@/shared/constants";

const api = axios.create({
  baseURL: process.env.VUE_APP_API_URL,
});

function showErrorMessage(exception) {
  // ToDo: Verify if it works
  vm.$snotify.error(exception.response.data.Message);
}

const client = {
  async get(resource, params) {
    const config = this.createConfig(params);

    try {
      return await api.get(resource, config);
    } catch (exception) {
      showErrorMessage(exception);
    }
  },
  async post(resource, data, params) {
    const config = this.createConfig(params);

    try {
      return await api.post(resource, data, config);
    } catch (exception) {
      showErrorMessage(exception);
    }
  },
  async put(resource, data, params) {
    const config = this.createConfig(params);

    try {
      return await api.put(resource, data, config);
    } catch (exception) {
      showErrorMessage(exception);
    }
  },
  async delete(resource, params) {
    const config = this.createConfig(params);

    try {
      return await api.delete(resource, config);
    } catch (exception) {
      showErrorMessage(exception);
    }
  },
  createConfig(params) {
    const authenticationResult = JSON.parse(
      localStorage.getItem(AuthenticationResultStorageKey)
    );

    const token = authenticationResult ? authenticationResult.jwt : null;

    return {
      params,
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
  },
};

api.interceptors.request.use(
  (config) => {
    store.commit("requestModule/incrementPendingRequestCount");
    return config;
  },
  (error) => {
    store.commit("requestModule/decrementPendingRequestCount");
    return Promise.reject(error);
  }
);

api.interceptors.response.use(
  (config) => {
    store.commit("requestModule/decrementPendingRequestCount");
    return config;
  },
  (error) => {
    store.commit("requestModule/decrementPendingRequestCount");
    return Promise.reject(error);
  }
);

export default client;
