<template>
  <section class="text-center centerized">
    <action-panel
      :panel-title="'Drużyny'"
      @addedButtonClicked="changeSquadDialogVisibility(true)"
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
      @canceled="changeSquadDialogVisibility(false)"
      @confirmed="changeSquadDialogVisibility(false)"
    ></add-squad-dialog>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddSquadDialog from "../addSquadDialog";
import ActionPanel from "@/shared/components/ActionPanel";

export default {
  name: "SquadList",
  components: {
    AddSquadDialog,
    ActionPanel,
  },
  data() {
    return {
      addSquadDialogVisibility: false,
      selectedSquad: null,
    };
  },
  watch: {
    selectedSquad() {
      console.log(this.selectedSquad);
    },
  },
  computed: {
    ...mapGetters("squadModule", ["squads"]),
  },
  methods: {
    ...mapActions("squadModule", ["getSquads", "addSquad"]),
    changeSquadDialogVisibility(visibility) {
      this.addSquadDialogVisibility = visibility;
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
