<template>
  <v-app-bar app dense clipped-left :color="headerBarColor" elevation="0">
    <v-menu class="hamburger-menu" rounded="0" :offset-y="true">
      <template v-slot:activator="{ on }">
        <v-app-bar-nav-icon
          default="ham"
          v-on="on"
          :color="Theme.headerLabelsColor"
          border
        />
      </template>
      <v-list class="">
        <v-list-item
          v-for="option in menuOptions"
          @click="onMenuOptionSelected(option.key)"
          :key="option.key"
        >
          <v-list-item-icon>
            <v-icon class="ml-1">
              {{ option.icon }}
            </v-icon>
          </v-list-item-icon>
          <v-list-item-title class="mr-2">{{ option.title }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
    <v-toolbar-title class="headline">
      <span class="app-title ml-2"> {{ Names.applicationName }}</span>
    </v-toolbar-title>
    <div class="clock" v-if="isClockVisible">
      <v-row>
        <span class="date-label ml-4">{{ dateTime | dateFilter }}</span>
      </v-row>
      <v-row style="margin-right: 230px">
        <span class="time-label">{{ dateTime | timeFilter }}</span>
      </v-row>
    </div>
  </v-app-bar>
</template>

<script>
import { Names, Theme } from "@/shared/constants";
import { MenuKeys, MenuOptions } from "./constants";
import { dateFilter, timeFilter } from "@/shared/filters";
import { mapActions } from "vuex";

export default {
  name: "HeaderBar",
  data() {
    return {
      Theme,
      Names,
      menuOptions: MenuOptions,
      aboutDialogVisibility: false,
      clock: null,
      dateTime: new Date(),
      dateFilter,
      timeFilter,
    };
  },
  computed: {
    headerBarColor() {
      return Theme.mainBackgroundColor;
    },
    isClockVisible() {
      return false;
    },
  },
  methods: {
    ...mapActions("authenticationModule", ["logout"]),
    onMenuOptionSelected(key) {
      switch (key) {
        case MenuKeys.Profile:
          this.$router.push("/profile");
          break;
        case MenuKeys.Squad:
          this.$router.push("/squad");
          break;
        case MenuKeys.Team:
          this.$router.push("/team");
          break;
        case MenuKeys.Item:
          this.$router.push("/item");
          break;
        case MenuKeys.AboutApplication:
          // ToDo: Open about dialog
          break;
        case MenuKeys.Logout:
          this.logout();
          this.$router.push("/login");
          break;
        default:
          break;
      }
    },
  },
};
</script>

<style lang="scss" scoped>
@import "@/assets/styles/_colors.scss";
.app-title {
  font-size: 22px;
  color: white;
}

.hamburger-menu {
  min-width: 48px;
  top: 65px;
  left: 0;
  transform-origin: left top;
  z-index: 8;
}

.clock {
  margin: 0 auto;
  text-align: center;
}

.time-label {
  color: white;
  font-family: "Roboto";
  font-size: 22px;
  font-weight: bold;
}

.date-label {
  color: lightGray;
  font-family: "Roboto";
  font-size: 12px;
  font-weight: bold;
}
</style>
