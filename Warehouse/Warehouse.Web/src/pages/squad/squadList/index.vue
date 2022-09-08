<template>
  <section class="text-center centerized">
    <v-btn color="primary" @click="showAddSquadDialog">Dodaj Drużynę</v-btn>
    <v-list>
      <v-list-item-group v-model="selectedSquad" color="primary">
        <v-list-item v-for="item in squads" :key="item.id">
          {{ item.name }}
        </v-list-item>
      </v-list-item-group>
    </v-list>
    <add-squad-dialog
      :dialog-visibility="addSquadDialogVisibility"
      @canceled="hideAddSquadDialog"
    ></add-squad-dialog>
    <edit-squad-dialog
      :dialog-visibility="editSquadDialogVisibility"
      :selectedSquad="selectedSquad"
      @canceled="changeEditSquadDialogVisibility(false)"
      @confirmed="changeEditSquadDialogVisibility(false)"
    />
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddSquadDialog from "../addSquadDialog";
import EditSquadDialog from "../editSquadDialog";

export default {
  name: "SquadList",
  components: {
    AddSquadDialog,
    EditSquadDialog,
  },
  data() {
    return {
      addSquadDialogVisibility: false,
      editSquadDialogVisibility: false,
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
