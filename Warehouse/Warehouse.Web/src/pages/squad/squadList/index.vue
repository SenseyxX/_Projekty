<template>
  <section class="text-center centerized">
    <v-btn color="primary" @click="showAddSquadDialog">Dodaj Drużynę</v-btn>
    <v-list>
      <v-list-item-group v-model="selectedSquad" color="primary">
        <v-list-item v-for="item in squads" :key="item.id">
          {{ item.name }}
          <template v-slot:item.actions="{ team }">
            <v-btn icon @click="editSquad(team)">
              <v-icon small dark>mdi-pencil-outline</v-icon>
            </v-btn>
            <v-btn icon @click="deleteSquad(team)">
              <v-icon small color="red">mdi-delete</v-icon>
            </v-btn>
          </template>
        </v-list-item>
      </v-list-item-group>
    </v-list>
    <add-squad-dialog
      :dialog-visibility="addSquadDialogVisibility"
      @canceled="hideAddSquadDialog"
    ></add-squad-dialog>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddSquadDialog from "../addSquadDialog";

export default {
  name: "SquadList",
  components: {
    AddSquadDialog,
  },
  data() {
    return {
      addSquadDialogVisibility: false,
      editSquadDialogVisibility: false,
      deleteSquadDialogVisibility: false,
      selectedSquad: null,
    };
  },
  watch: {
    selectedSquad() {
      const selected = this.squads.at(this.selectedSquad);
      this.$emit("squadSelected", selected);
    },
  },
  computed: {
    ...mapGetters("squadModule", ["squads"]),
  },
  methods: {
    ...mapActions("squadModule", ["getSquads", "addSquad"]),
    showAddSquadDialog() {
      this.addSquadDialogVisibility = true;
    },
    hideAddSquadDialog() {
      this.addSquadDialogVisibility = false;
    },
    showEditSquadDialog() {
      this.editSquadDialogVisibility = true;
    },
    hideEditSquadDialog() {
      this.editSquadDialogVisibility = false;
    },
    showDeleteSquadDialog() {
      this.deleteSquadDialogVisibility = true;
    },
    hideDeleteSquadDialog() {
      this.deleteSquadDialogVisibility = false;
    },
    deleteSquad(squad) {
      this.selectedSquad = squad;
      this.showDeleteSquadDialog();
    },
    editSquad(squad) {
      this.selectedSquad = squad;
      this.showEditSquadDialog();
    },
  },
  async mounted() {
    await this.getSquads();
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
