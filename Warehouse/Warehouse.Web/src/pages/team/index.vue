<template>
  <section class="text-center centerized">
    <action-panel
      :panel-title="'Zastępy'"
      @addedButtonClicked="changeTeamDialogVisibility(true)"
    />
    <v-row>
      <v-col>
        <team-list @teamSelected="onTeamSelected" />
      </v-col>
      <v-col v-if="selectedTeam">
        <team-information :team="selectedTeam" />
      </v-col>
    </v-row>
    <add-team-dialog
      :dialog-visibility="addTeamDialogVisibility"
      @canceled="changeTeamDialogVisibility(false)"
      @confirmed="changeTeamDialogVisibility(false)"
    ></add-team-dialog>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import TeamList from "@/pages/team/teamList";
import TeamInformation from "@/pages/team/teamInformation";
import AddTeamDialog from "@/pages/team/addTeamDialog";
import ActionPanel from "@/shared/components/ActionPanel";

export default {
  name: "TeamPage",
  components: {
    TeamList,
    TeamInformation,
    AddTeamDialog,
    ActionPanel,
  },
  data() {
    return {
      addTeamDialogVisibility: false,
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
    changeTeamDialogVisibility(visibility) {
      this.addTeamDialogVisibility = visibility;
    },
    onTeamSelected(team) {
      if (team) {
        console.log(team);
        this.selectedTeam = team;
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
