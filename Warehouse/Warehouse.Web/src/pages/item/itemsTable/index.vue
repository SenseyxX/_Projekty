<template>
  <section class="text-center centerized">
    <v-row>
      <v-col md="3">
        <v-text-field
          v-model="search"
          append-icon="mdi-magnify"
          label="Szukaj"
          single-line
          hide-details
        ></v-text-field>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-data-table
          :headers="headers"
          :items="filteredItems"
          :search="search"
          item-key="id"
        >
          <template>
            <v-icon>"mdi-delete"</v-icon>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "ItemsTable",
  components: {},
  props: {},
  data() {
    return {
      search: "",
      headers: [
        { text: "Nazwa", value: "name" },
        { text: "Opis", value: "description", sortable: false },
        { text: "Kategoria", value: "categoryName" },
        { text: "Stan", value: "qualityLevel" }, //ToDo: Change QualityLevel to QualityLevelName
        { text: "Ilośc", value: "quantity" },
        { text: "Właściciel", value: "ownerName" },
        { text: "Posiadacz", value: "actualOwnerName" },
        { text: "Akcje", value: "actions", sortable: false },
      ],
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("itemModule", ["items"]),
    filteredItems() {
      return this.items.filter(
        (item) => item.ownerId === this.authenticationResult.tokenOwner.id
      );
    },
  },
  methods: {
    ...mapActions("itemModule", ["getItems"]),
  },

  async mounted() {
    await this.getItems();
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
