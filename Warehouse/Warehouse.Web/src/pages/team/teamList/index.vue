<template>
  <section class="text-center centerized">
    <v-btn color="primary" @click="showAddTeamDialog">Dodaj zastęp</v-btn>
    <v-list>
      <v-list-item-group v-model="selectedTeam" color="primary">
        <v-list-item v-for="item in teams" :key="item.id" :value="item">
          {{ item.name }}
        </v-list-item>
      </v-list-item-group>
    </v-list>
    <add-team-dialog
      :dialog-visibility="addTeamDialogVisibility"
      @canceled="hideAddTeamDialog"
    />
  </section>
</template>

<script>
import { mapGetters } from "vuex";
import AddTeamDialog from "@/pages/team/addTeamDialog";

export default {
  name: "TeamList",
  components: {
    AddTeamDialog,
  },
  data() {
    return {
      addTeamDialogVisibility: false,
      selectedTeam: null,
    };
  },
  watch: {
    selectedTeam() {
      if (this.selectedTeam) {
        this.$emit("teamSelected", this.selectedTeam);
      }
    },
  },
  computed: {
    ...mapGetters("squadModule", ["teams"]),
  },
  methods: {
    showAddTeamDialog() {
      this.addTeamDialogVisibility = true;
    },
    hideAddTeamDialog() {
      this.addTeamDialogVisibility = false;
    },
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
