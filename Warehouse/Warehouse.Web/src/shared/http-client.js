import axios from "axios";
import vm from "@/main";
import store from "@/store";

const api = axios.create({
  baseURL: process.env.VUE_APP_API_URL,
});

function showErrorMessage(exception) {
  // ToDo: Verify if it works
  vm.$snotify.error(exception.response.data.Message);
}

const client = {
  async get(resource, params) {
    try {
      return await api.get(resource, params);
    } catch (exception) {
      showErrorMessage(exception);
    }
  },
  async post(resource, data, params) {
    try {
      return await api.post(resource, data, params);
    } catch (exception) {
      showErrorMessage(exception);
    }
  },
  async put(resource, data, params) {
    try {
      return await api.put(resource, data, params);
    } catch (exception) {
      showErrorMessage(exception);
    }
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
