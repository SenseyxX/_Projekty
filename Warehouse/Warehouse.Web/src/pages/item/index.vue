<template>
  <section class="text-center centerized">
    <v-row>
      <items-table />
    </v-row>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import ItemsTable from "./itemsTable";

export default {
  name: "ItemPage",
  components: {
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
