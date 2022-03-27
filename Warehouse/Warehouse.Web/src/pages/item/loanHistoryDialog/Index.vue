<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <p class="ma-4 text-h6">Historia wypożyczeń</p>
      <div class="select-group">
        <v-data-table
          :headers="headers"
          :items="loanHistory"
          item-key="id"
        ></v-data-table>
      </div>
      <v-container>
        <v-row class="buttons-group" justify="end">
          <v-btn @click="cancel" text color="primary" outlined class="mr-8">
            Anuluj
          </v-btn>
        </v-row>
      </v-container>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "loanHistoryDialog",
  data: () => ({
    name: "",
    isValid: false,
    headers: [
      { text: "Data", value: "timestamp" },
      { text: "Przedmiot", value: "itemId" },
      { text: "Pożyczający", value: "borrowerId" },
      { text: "Wypozyczający", value: "receiverId" },
    ],
  }),
  props: {
    dialogVisibility: {
      type: Boolean,
      defaultValue: false,
    },
    loanHistory: {
      type: Object,
      defaultValue: null,
    },
  },
  computed: {
    ...mapGetters("itemModule", ["loanhistory"]),
  },
  methods: {
    ...mapActions("itemModule", ["getItemLoanHistory"]),
    cancel() {
      this.$emit("canceled");
    },
  },
  // ToDo: add selected itemId to endpoint
  // async mounted() {
  //   await this.getItemLoanHistory(item.id);
  // },
};
</script>

<style scoped></style>
