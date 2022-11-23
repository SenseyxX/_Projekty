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
        >
          <template v-slot:item.actions="{ user }">
            <v-btn icon @click="editUser(user)">
              <v-icon small dakr>mdi-pencil-outline</v-icon>
            </v-btn>
            <v-btn icon @click="deleteUser(user)">
              <v-icon small color="red">mdi-delete</v-icon>
            </v-btn>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
    <assign-user-dialog
      :dialog-visibility="assignUserDialogVisibility"
      @canceled="hideAssignUserDialog"
    />
    <edit-user-dialog
      :dialog-visibility="editUserDialogVisibility"
      :item="selectedUser"
      @confirmed="hideEditUserDialog"
      @canceled="hideEditUserDialog"
    />
    <delete-user-dialog
      :dialog-visibility="deleteUserDialogVisibility"
      :item="selectedUser"
      @confirmed="hideDeleteUserDialog"
      @canceled="hideDeleteUserDialog"
    />
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AssignUserDialog from "@/pages/team/assignUserDialog";
import EditUserDialog from "@/pages/team/editUserDialog";
import DeleteUserDialog from "@/pages/team/deleteUserDialog";

export default {
  name: "UsersTable",
  components: {
    AssignUserDialog,
    EditUserDialog,
    DeleteUserDialog,
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
      headers: [
        { text: "Imię", value: "name" },
        { text: "Nazwisko", value: "lastName" },
        { text: "E-mail", value: "email" },
        { text: "Telefon", value: "phoneNumber" },
        { text: "Akcje", value: "actions", sortable: false },
      ],
      assignUserDialogVisibility: false,
      editUserDialogVisibility: false,
      deleteUserDialogVisibility: false,
      selectedUser: {},
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
    showEditUserDialog() {
      this.editUserDialogVisibility = true;
    },
    hideEditUserDialog() {
      this.editUserDialogVisibility = false;
    },
    showDeleteUserDialog() {
      this.deleteUserDialogVisibility = true;
    },
    hideDeleteUserDialog() {
      this.deleteUserDialogVisibility = false;
    },
    deleteUser(user) {
      this.selectedUser = user;
      this.showDeleteItemDialog();
    },
    editUser(user) {
      this.selectedUser = user;
      this.showEditUserDialog();
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
