import Vue from "vue";
import moment from "moment";

Vue.prototype.moment = moment;

export function dateFilter(date) {
  if (!date) {
    return "-";
  }
  return moment(date, "DD-MM-YYYY").format("DD.MM.YYYY");
}
export function dateFilterDatePicker(date) {
  if (!date) {
    return "-";
  }
  return moment(date, "YYYY-MM-DD").format("YYYY-MM-DD");
}

export function timeFilter(date) {
  if (!date) {
    return "-";
  }
  return moment(date).format("HH:mm:ss");
}

export function shortTimeFilter(date) {
  if (!date) {
    return "-";
  }
  return moment(date).format("HH:mm");
}
