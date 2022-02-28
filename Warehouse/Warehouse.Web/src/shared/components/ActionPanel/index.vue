<template>
  <v-container class="flex-column pa-2">
    <v-container class="d-inline-flex pa-2">
      <span>{{ panelTitle }}</span>
    </v-container>
    <v-container class="d-inline-flex pa-2">
      <v-btn class="button" @click="onAddButtonClicked">+</v-btn>
      <v-btn class="button" @click="onEditButtonClicked">-</v-btn>
      <v-btn class="button">Delete</v-btn>
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
    onEditButtonClicked() {
      this.$emit("editButtonClicked");
    },
  },
};
</script>

<style scoped>
.actionPanel {
  flex-flow: column;
}

.button {
  margin: 50px;
  width: 5%;
}

.searchBar {
  margin: 50px;
  max-width: 20%;
}
</style>
