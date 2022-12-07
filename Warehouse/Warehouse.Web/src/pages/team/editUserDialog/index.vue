<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Edytowanie użytkownika</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form">
            <v-text-field v-model="name" label="Nowe imię" />
            <v-text-field v-model="lastName" label="Nowe nazwisko" />
            <v-text-field v-model="email" label="Nowy E-mail" />
            <v-text-field v-model="phoneNumber" label="Nowy numer telefonu" />
            <v-select
              v-model="selectedSquad"
              label="Drużyna"
              :items="squads"
              item-text="name"
              item-value="id"
            ></v-select>
            <v-select
              v-model="selectedTeam"
              label="Zastęp"
              :items="teams"
              item-text="name"
              item-value="id"
            ></v-select>
          </v-form>
        </div>
        <v-container>
          <v-row class="buttons-group" justify="end">
            <v-btn @click="cancel" text color="primary" outlined class="mr-8">
              Anuluj
            </v-btn>
            <v-btn @click="saveChanges" color="primary" class="mr-8">
              Zapisz
            </v-btn>
          </v-row>
        </v-container>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "editUserDialog",
  data: () => ({
    id: "",
    name: "",
    lastName: "",
    email: "",
    phoneNumber: "",
    squadId: "",
    selectedSquad: null,
    teamId: "",
    selectedTeam: null,
  }),
  props: {
    dialogVisibility: {
      type: Boolean,
      defaultValue: false,
    },
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("userModule", ["user"]),
    ...mapGetters("squadModule", ["squads"]),
    ...mapGetters("squadModule", ["teams"]),
  },
  methods: {
    ...mapActions("userModule", ["getUser", "updateUser"]),
    ...mapActions("squadModule", ["getSquads", "getSquadTeams"]),
    async saveChanges() {
      const command = {
        id: this.id,
        name: this.name,
        lastName: this.lastName,
        email: this.email,
        phoneNumber: this.phoneNumber,
        squadid: this.selectedSquad,
        teamid: this.selectedTeam,
      };

      await this.updateUser(command);

      this.$emit("confirmed");
      this.$emit("canceled");
      this.clearPropos();
    },
    async clearPropos() {
      (this.id = ""),
        (this.name = ""),
        (this.lastName = ""),
        (this.password = ""),
        (this.email = ""),
        (this.phoneNumber = ""),
        (this.squadId = ""),
        (this.teamId = "");
    },
    cancel() {
      this.$emit("canceled");
    },
    async mounted() {
      await this.getSquads();
    },
  },
};
</script>

<style scoped></style>
