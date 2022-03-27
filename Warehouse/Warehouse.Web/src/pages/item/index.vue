<template>
  <section class="text-center centerized">
    <v-row>
      <action-panel
        :panel-title="'Przedmioty'"
        @addedButtonClicked="changeItemDialogVisibility(true)"
      />
      <v-spacer />
    </v-row>
    <v-row>
      <add-item-dialog
        :dialog-visibility="addItemDialogVisibility"
        @canceled="changeItemDialogVisibility(false)"
        @confirmed="changeItemDialogVisibility(false)"
      ></add-item-dialog>
    </v-row>
    <v-row>
      <items-table />
    </v-row>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddItemDialog from "./addItemDialog";
import ActionPanel from "@/shared/components/ActionPanel";
import ItemsTable from "./itemsTable";

export default {
  name: "ItemPage",
  components: {
    AddItemDialog,
    ActionPanel,
    ItemsTable,
  },
  data() {
    return {
      addItemDialogVisibility: false,
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("itemModule", ["item"]),
  },
  methods: {
    ...mapActions("authenticationModule", ["authenticate"]),
    ...mapActions("itemModule", ["addItem", "getItem"]),
    changeItemDialogVisibility(visibility) {
      this.addItemDialogVisibility = visibility;
    },
  },
  async mounted() {
    await this.getItem(this.authenticationResult.tokenOwner.id);
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
