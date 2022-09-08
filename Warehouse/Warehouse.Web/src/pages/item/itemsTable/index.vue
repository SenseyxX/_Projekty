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
          <template v-slot:item.actions="{ item }">
            <v-btn icon @click="editItem(item)">
              <v-icon small dakr>mdi-pencil-outline</v-icon>
            </v-btn>
            <v-btn icon @click="deleteItem(item)">
              <v-icon small color="red">mdi-delete</v-icon>
            </v-btn>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
    <add-item-dialog
      :dialog-visibility="addItemDialogVisibility"
      @confirmed="hideAddItemDialog"
      @canceled="hideAddItemDialog"
    />
    <add-category-dialog
      :dialog-visibility="addCategoryDialogVisibility"
      @canceled="hideAddCategoryDialog"
    />
    <edit-item-dialog
      :dialog-visibility="editItemDialogVisibility"
      :item="selectedItem"
      @confirmed="hideEditItemDialog"
      @canceled="hideEditItemDialog"
    />
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import addCategoryDialog from "@/pages/item/addCategoryDialog";
import addItemDialog from "@/pages/item/addItemDialog";
import editItemDialog from "@/pages/item/editItemDialog";

export default {
  name: "ItemsTable",
  components: {
    addItemDialog,
    addCategoryDialog,
    editItemDialog,
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
      editItemDialogVisibility: false,
      selectedItem: {},
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
    showEditItemDialog() {
      this.editItemDialogVisibility = true;
    },
    hideEditItemDialog() {
      this.editItemDialogVisibility = false;
    },
    deleteItem(item) {
      console.log(item);
    },
    editItem(item) {
      this.selectedItem = item;
      this.showEditItemDialog();
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
