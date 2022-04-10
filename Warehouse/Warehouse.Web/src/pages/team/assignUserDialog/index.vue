<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Przypisywanie użytkowników do zastępu</p>
      </v-toolbar>
      <div class="select-group"></div>
      Użytkownicy w zastępie
      <!--ToDo: add multiple selects with all unassigned users to team on selected team-->
      <v-container>
        <v-row class="buttons-group" justify="end">
          <v-btn @click="cancel" text color="primary" outlined class="mr-8">
            Anuluj
          </v-btn>
          <v-btn
            @click="saveChanges"
            color="primary"
            class="mr-8"
            :disabled="!isValid"
          >
            Zapisz
          </v-btn>
        </v-row>
      </v-container>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "assignUserDialog",
  data: () => ({
    userId: "",
    name: "",
    teamId: "",
    isValid: false,
  }),
  props: {
    dialogVisibility: {
      type: Boolean,
      defaultValue: false,
    },
    selectedTeam: {
      type: Object,
      defaultValue: false,
    },
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
  },
  methods: {
    ...mapActions("userModule", ["getUsers"]),
    //ToDo: add PUT user Endpoint
    //ToDo: add method to filter chosen team
    async saveChanges() {
      const command = {
        id: this.userId,
        name: this.name,
        teamId: this.selectedTeam.id,
      };

      await this.editUser(command);

      this.$emit("confirmed");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
};
</script>

<style scoped></style>
