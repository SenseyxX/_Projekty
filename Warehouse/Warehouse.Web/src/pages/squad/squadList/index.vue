<template>
  <section class="text-center centerized">
    <action-panel
      :panel-title="'Drużyny'"
      @addedButtonClicked="changeAddSquadDialogVisibility(true)"
      @editedButtonClicked="changeEditSquadDialogVisibility(true)"
    />
    <v-list>
      <v-list-item-group v-model="selectedSquad" color="primary">
        <v-list-item v-for="item in squads" :key="item.id">
          {{ item.name }}
        </v-list-item>
      </v-list-item-group>
    </v-list>
    <add-squad-dialog
      :dialog-visibility="addSquadDialogVisibility"
      @canceled="changeAddSquadDialogVisibility(false)"
      @confirmed="changeAddSquadDialogVisibility(false)"
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
import ActionPanel from "@/shared/components/ActionPanel";

export default {
  name: "SquadList",
  components: {
    AddSquadDialog,
    EditSquadDialog,
    ActionPanel,
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
    changeAddSquadDialogVisibility(visibility) {
      this.addSquadDialogVisibility = visibility;
    },
    changeEditSquadDialogVisibility(visibility) {
      this.editSquadDialogVisibility = visibility;
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
