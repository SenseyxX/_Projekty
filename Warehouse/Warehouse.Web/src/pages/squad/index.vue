<template>
  <section class="text-center centerized">
    <v-row>
      <v-col>
        <v-btn @click="onAddButtonClicked">+</v-btn>
      </v-col>
      <v-col>
        {{ squad.name }}
      </v-coL>
    </v-row>
    <add-squad-dialog
      :dialog-visibility="addSquadDialogVisibility"
      @canceled="closeAddSquadDialog"
      @confirmed="closeAddSquadDialog"
    ></add-squad-dialog>
  </section>
</template>

<script>
// import { Theme } from "@/shared/constants";
import { mapGetters, mapActions } from "vuex";
import AddSquadDialog from "./addSquadDialog";

export default {
  name: "SquadPage",
  components: {
    AddSquadDialog,
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
    onAddButtonClicked() {
      this.addSquadDialogVisibility = true;
    },
    closeAddSquadDialog() {
      this.addSquadDialogVisibility = false;
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
