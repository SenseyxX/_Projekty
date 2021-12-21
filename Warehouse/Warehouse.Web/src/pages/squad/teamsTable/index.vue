<template>
  <section class="text-center centerized"></section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import { teamsTableHeaders } from "@/pages/squad/teamsTable/headers";

export default {
  name: "TeamsTable",
  data() {
    return {
      teamsTableHeaders,
    };
  },
  computed: {
    ...mapGetters("squadModule", ["squad"]),
  },
  methods: {
    ...mapActions("squadModule", ["addSquad"]),
  },
  async mounted() {},
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
