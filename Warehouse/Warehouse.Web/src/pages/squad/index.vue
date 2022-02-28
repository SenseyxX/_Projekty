<template>
  <section class="text-center centerized">
    <v-row>
      <action-panel
        :panel-title="'Składy'"
        @addedButtonClicked="changeSquadDialogVisibility(true)"
      />
      <v-spacer />
    </v-row>
    <add-squad-dialog
      :dialog-visibility="addSquadDialogVisibility"
      @canceled="changeSquadDialogVisibility(false)"
      @confirmed="changeSquadDialogVisibility(false)"
    ></add-squad-dialog>
  </section>
</template>

<script>
// import { Theme } from "@/shared/constants";
import { mapGetters, mapActions } from "vuex";
import AddSquadDialog from "./addSquadDialog";
import ActionPanel from "@/shared/components/ActionPanel";

export default {
  name: "SquadPage",
  components: {
    AddSquadDialog,
    ActionPanel,
  },
  data() {
    return {
      addSquadDialogVisibility: false,
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("squadModule", ["squad"]),
  },
  methods: {
    ...mapActions("authenticationModule", ["authenticate"]),
    ...mapActions("squadModule", ["getSquad", "addSquad"]),
    changeSquadDialogVisibility(visibility) {
      this.addSquadDialogVisibility = visibility;
    },
  },
  async mounted() {
    await this.getSquad(this.authenticationResult.tokenOwner.id);
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
