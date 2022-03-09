<template>
  <section class="text-center centerized">
    <action-panel
      :panel-title="'Zastępy'"
      @addedButtonClicked="changeTeamDialogVisibility(true)"
    />
    <v-list>
      <v-list-item-group v-model="selectedTeam" color="primary">
        <v-list-item v-for="item in teams" :key="item.id">
          {{ item.name }}
        </v-list-item>
      </v-list-item-group>
    </v-list>
    <add-team-dialog
      :dialog-visibility="addTeamDialogVisibility"
      @canceled="changeTeamDialogVisibility(false)"
      @confirmed="changeTeamDialogVisibility(false)"
    ></add-team-dialog>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddTeamDialog from "../addTeamDialog";
import ActionPanel from "@/shared/components/ActionPanel";

export default {
  name: "TeamList",
  components: {
    AddTeamDialog,
    ActionPanel,
  },
  data() {
    return {
      addTeamDialogVisibility: false,
      selectedTeam: null,
    };
  },
  watch: {
    selectedTeam() {
      console.log(this.selectedTeam);
    },
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("squadModule", ["teams"]),
  },
  methods: {
    ...mapActions("squadModule", ["getSquadTeams", "addTeam"]),
    changeTeamDialogVisibility(visibility) {
      this.addTeamDialogVisibility = visibility;
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
</style>
