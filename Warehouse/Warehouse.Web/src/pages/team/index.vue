<template>
  <section class="text-center centerized">
    <v-row>
      <v-col>
        <team-list @teamSelected="onTeamSelected" />
      </v-col>
      <v-col v-if="selectedTeam">
        <team-information :team="selectedTeam" />
      </v-col>
    </v-row>
    <v-row v-if="selectedTeam">
      <users-table :team="selectedTeam" />
    </v-row>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import TeamList from "@/pages/team/teamList";
import TeamInformation from "@/pages/team/teamInformation";
import UsersTable from "@/pages/team/usersTable";

export default {
  name: "TeamPage",
  components: {
    TeamList,
    TeamInformation,
    UsersTable,
  },
  data() {
    return {
      selectedTeam: null,
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("squadModule", ["team"]),
  },
  methods: {
    ...mapActions("authenticationModule", ["authenticate"]),
    ...mapActions("squadModule", ["getSquadTeams"]),
    onTeamSelected(team) {
      if (team) {
        this.selectedTeam = team;
        console.log(team);
      }
    },
  },
  async mounted() {
    await this.getSquadTeams(this.authenticationResult.tokenOwner.squadId);
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
