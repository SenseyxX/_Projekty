<template>
  <section class="text-center centerized">
    <v-row>
      <v-col>
        <v-btn color="primary" @click="showAddCategoryDialog"
          >Dodaj kategorie</v-btn
        >
      </v-col>
      <v-col>
        <v-btn color="primary" @click="showAddItemDialog"
          >Dodaj przedmiot</v-btn
        >
      </v-col>
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
    <add-item-dialog
      :dialog-visibility="addItemDialogVisibility"
      @canceled="hideAddItemDialog"
    />
    <add-category-dialog
      :dialog-visibility="addCategoryDialogVisibility"
      @canceled="hideAddCategoryDialog"
    />
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import addCategoryDialog from "@/pages/item/addCategoryDialog";
import addItemDialog from "@/pages/item/addItemDialog";

export default {
  name: "ItemsTable",
  components: {
    addItemDialog,
    addCategoryDialog,
  },
  props: {},
  data() {
    return {
      search: "",
      headers: [
        { text: "Nazwa", value: "name" },
        { text: "Opis", value: "description", sortable: false },
        { text: "Kategoria", value: "categoryName" },
        { text: "Stan", value: "qualityLevel" }, //ToDo: Change QualityLevel to QualityLevelName
        { text: "Ilość [szt]", value: "quantity" },
        { text: "Właściciel", value: "ownerName" },
        { text: "Posiadacz", value: "actualOwnerName" },
        { text: "Akcje", value: "actions", sortable: false },
      ],
      addItemDialogVisibility: false,
      addCategoryDialogVisibility: false,
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

    showAddItemDialog() {
      this.addItemDialogVisibility = true;
    },
    hideAddItemDialog() {
      this.addItemDialogVisibility = false;
    },
    showAddCategoryDialog() {
      this.addCategoryDialogVisibility = true;
    },
    hideAddCategoryDialog() {
      this.addCategoryDialogVisibility = false;
    },
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
