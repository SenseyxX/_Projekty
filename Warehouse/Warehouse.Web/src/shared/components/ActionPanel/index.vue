<template>
  <v-container class="flex-column pa-2">
    <v-container class="d-inline-flex pa-2">
      <span>{{ panelTitle }}</span>
    </v-container>
    <v-container class="d-inline-flex pa-2">
      <v-btn class="button" @click="onAddButtonClicked"
        ><v-icon dark> mdi-plus-circle</v-icon></v-btn
      >
      <v-btn class="button" @click="onDeletedButtonClicked">
        <v-icon dark> mdi-minus-circle</v-icon></v-btn
      >
      <v-text-field
        v-if="searchBarVisibility"
        v-model="searchResult"
        outlined
        class="searchBar"
      ></v-text-field>
    </v-container>
  </v-container>
</template>

<script>
export default {
  name: "actionPanel",
  props: {
    panelTitle: {
      type: String,
      defaultValue: "",
    },
    // ToDo: Add buttons visibility
    searchBarVisibility: {
      type: Boolean,
      defaultValue: false,
    },
  },
  data: () => ({
    searchResult: "",
  }),
  methods: {
    onAddButtonClicked() {
      this.$emit("addedButtonClicked");
    },
    onDeletedButtonClicked() {
      this.$emit("deletedButtonClicked");
    },
  },
};
</script>

<style scoped>
.button {
  margin-left: 50px;
  width: 5%;
}

.searchBar {
  margin-left: 50px;
  max-width: 20%;
}
</style>
