<template>
  <v-app
    :style="{
      'background-color': Theme.containerBackgroundColor,
      overflow: 'hidden',
    }"
  >
    <headerBar />
    <v-main>
      <router-view />
      <loader />
    </v-main>
    <vue-snotify />
    <keep-alive>
      <footer-bar />
    </keep-alive>
  </v-app>
</template>

<script>
import HeaderBar from "@/shared/components/HeaderBar";
import FooterBar from "@/shared/components/FooterBar";
import Loader from "@/shared/components/Loader";
import { Theme } from "@/shared/constants";
import { mapActions, mapGetters } from "vuex";

export default {
  name: "App",
  components: {
    HeaderBar,
    FooterBar,
    Loader,
  },
  watch: {
    $route: {
      immediate: true,
      handler(to) {
        this.routeName = to.name;
      },
    },
  },
  methods: {
    ...mapActions("authenticationModule", ["recallAuthenticationResult"]),
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
  },
  data: () => ({
    Theme,
    routeName: null,
  }),
  created() {
    this.recallAuthenticationResult();
  },
};
</script>
