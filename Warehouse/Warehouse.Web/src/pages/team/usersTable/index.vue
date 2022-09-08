<template>
  <section class="text-center centerized">
    <v-row>
      <v-col />
      <v-col>
        <v-btn color="primary" @click="showAssignUserDialog"
          >Przypisz do Zastępu</v-btn
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
          :items="filteredUsers"
          :search="search"
          item-key="id"
        ></v-data-table>
      </v-col>
    </v-row>
    <assign-user-dialog
      :dialog-visibility="assignUserDialogVisibility"
      @canceled="hideAssignUserDialog"
    />
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AssignUserDialog from "@/pages/team/assignUserDialog";

export default {
  name: "UsersTable",
  components: {
    AssignUserDialog,
  },
  props: {
    team: {
      type: Object,
      defaultValue: null,
    },
  },
  data() {
    return {
      search: "",
      assignUserDialogVisibility: false,
      headers: [
        { text: "Imię", value: "name" },
        { text: "Nazwisko", value: "lastName" },
        { text: "E-mail", value: "email" },
        { text: "Telefon", value: "phoneNumber" },
      ],
    };
  },
  computed: {
    ...mapGetters("userModule", ["users"]),
    filteredUsers() {
      return this.users.filter((users) => users.teamId === this.team.id);
    },
  },
  methods: {
    ...mapActions("userModule", ["getUsers"]),
    showAssignUserDialog() {
      this.assignUserDialogVisibility = true;
    },
    hideAssignUserDialog() {
      this.assignUserDialogVisibility = false;
    },
  },

  async mounted() {
    await this.getUsers();
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
