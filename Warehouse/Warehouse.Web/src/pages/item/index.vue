<template>
  <section class="text-center centerized">
    <h6 class="title">Itemy</h6>
  </section>
</template>

<script>
import { Theme } from "@/shared/constants";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "ItemPage",
  data() {
    return {
      loginValue: "",
      passwordValue: "",
      Theme,
      isValid: false,
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
  },
  methods: {
    ...mapActions("authenticationModule", ["authenticate"]),
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}

.text-label {
  margin: 5vh 1vw 1vw;
  max-width: 250px;
  min-width: 200px;
}

.page-button {
  height: 40px;
  min-width: 400px;
  color: white;
}
</style>
