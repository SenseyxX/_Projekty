<template>
  <section class="text-center centerized">
    <v-row>
      <v-col>
        <v-btn>+</v-btn>
      </v-col>
      <v-col>
        {{ item.name }}
      </v-col>
    </v-row>
    <add-item-dialog
      :dialog-visibility="addItemDialogVisibility"
      @canceled="closeAddItemDialog"
      @confirmed="closeAddItemDialog"
    ></add-item-dialog>
  </section>
</template>

<script>
// import { Theme } from "@/shared/constants";
import { mapGetters, mapActions } from "vuex";
import AddItemDialog from "./addItemDialog";

export default {
  name: "ItemPage",
  components: {
    AddItemDialog,
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
    ...mapActions("itemModule", ["item"]),
    onAddButtonClicked() {
      this.addItemDialogVisibility = true;
    },
    closeAddItemDialog() {
      this.addItemDialogVisibility = false;
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
