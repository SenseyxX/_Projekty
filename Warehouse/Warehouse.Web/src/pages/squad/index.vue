<template>
  <section class="text-center centerized">
    <v-row>
      <v-col>
        <squad-list />
      </v-col>
      <v-col v-if="selectedSquad">
        <squad-information :squad="onSquadSelected" />
      </v-col>
    </v-row>
    <v-row>
      <team-table />
    </v-row>
  </section>
</template>

<script>
import SquadList from "@/pages/squad/squadList";
import TeamTable from "@/pages/squad/teamsTable";
import SquadInformation from "@/pages/squad/squadInformation";
import { mapActions, mapGetters } from "vuex";

export default {
  name: "SquadPage",
  components: {
    SquadList,
    TeamTable,
    SquadInformation,
  },
  data() {
    return {
      addSquadDialogVisibility: false,
      selectedSquad: null,
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("squadModule", ["squad"]),
  },
  methods: {
    ...mapActions("authenticationModule", ["authenticate"]),
    ...mapActions("squadModule", ["getSquad"]),
    onSquadSelected(squad) {
      if (squad) {
        this.selectedSquad = squad;
        console.log(squad);
      }
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
