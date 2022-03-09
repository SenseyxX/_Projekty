<template>
  <section class="text-center centerized">
    <team-list />
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import TeamList from "@/pages/team/teamList";

export default {
  name: "TeamPage",
  components: {
    TeamList,
  },
  data() {
    return {
      addTeamDialogVisibility: false,
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("squadModule", ["team"]),
  },
  methods: {
    ...mapActions("authenticationModule", ["authenticate"]),
    ...mapActions("squadModule", ["addTeam"]),
    changeTeamDialogVisibility(visibility) {
      this.addTeamDialogVisibility = visibility;
    },
  },
  async mounted() {},
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
