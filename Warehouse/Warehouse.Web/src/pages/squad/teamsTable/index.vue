<template>
  <section class="text-center centerized">
    <v-row>
      <v-col />
      <v-col md="3">
        <v-text-field
          v-model="search"
          append-icon="mdi-magnify"
          label="Szukaj"
          single-line
          hide-details
        ></v-text-field>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-data-table
          :headers="headers"
          :items="filteredTeams"
          :search="search"
          item-key="id"
        >
          <template v-slot:item.actions="{ team }">
            <v-btn icon @click="editTeam(team)">
              <v-icon small dakr>mdi-pencil-outline</v-icon>
            </v-btn>
            <v-btn icon @click="deleteTeam(team)">
              <v-icon small color="red">mdi-delete</v-icon>
            </v-btn>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
    <edit-team-dialog
      :dialog-visibility="editTeamDialogVisibility"
      :item="selectedTeam"
      @confirmed="hideEditTeamDialog"
      @canceled="hideEditTeamDialog"
    />
    <delete-Team-dialog
      :dialog-visibility="deleteTeamDialogVisibility"
      :item="selectedTeam"
      @confirmed="hideDeleteTeamDialog"
      @canceled="hideDeleteTeamDialog"
    />
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import editTeamDialog from "@/pages/team/editTeamDialog";
import deleteTeamDialog from "@/pages/team/deleteTeamDialog";
export default {
  name: "TeamTable",
  components: {
    editTeamDialog,
    deleteTeamDialog,
  },
  props: {
    selectedsquad: {
      type: Object,
      defaultValue: null,
    },
  },
  data() {
    return {
      search: "",
      headers: [
        { text: "Nazwa", value: "name" },
        { text: "Drużyna", value: "squadName" },
        { text: "Zastępowy", value: "teamOwnerName" },
        { text: "Punkty", value: "points" },
        { text: "Akcje", value: "actions", sortable: false },
      ],
      editTeamDialogVisibility: false,
      deleteTeamDialogVisibility: false,
      selectedTeam: {},
    };
  },
  computed: {
    ...mapGetters("squadModule", ["teams"]),
    ...mapGetters("userModule", ["users"]),
    filteredTeams() {
      return this.teams.filter(
        (teams) => teams.squadId === this.selectedsquad.id
      );
    },
  },
  methods: {
    ...mapActions("squadModule", ["getSquadTeams"]),
    ...mapActions("userModule", ["getUsers"]),
    userName(squadOwnerId) {
      const user = this.users.find((user) => user.id === squadOwnerId);
      return user.name + " " + user.lastName;
    },
    showEditTeamDialog() {
      this.editTeamDialogVisibility = true;
    },
    hideEditTeamDialog() {
      this.editTeamDialogVisibility = false;
    },
    showDeleteTeamDialog() {
      this.deleteTeamDialogVisibility = true;
    },
    hideDeleteTeamDialog() {
      this.deleteTeamDialogVisibility = false;
    },
    deleteTeam(team) {
      this.selectedTeam = team;
      this.showDeleteTeamDialog();
    },
    editTeam(team) {
      this.selectedTeam = team;
      console.log("edycja zastępu");
      this.showEditTeamDialog();
    },
  },

  async mounted() {
    await this.getSquadTeams(this.selectedsquad.id);
    await this.getUsers();
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
