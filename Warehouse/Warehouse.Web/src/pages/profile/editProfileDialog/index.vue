<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Edytowanie Profilu</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form">
            <v-text-field v-model="name" label="Nowe imię" />
            <v-text-field v-model="lastName" label="Nowe nazwisko" />
            <v-text-field v-model="password" label="Nowe hasło" />
            <v-text-field v-model="email" label="Nowy E-mail" />
            <v-text-field v-model="phoneNumber" label="Nowy numer telefonu" />
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
  name: "editProfileDialog",
  data: () => ({
    id: "",
    name: "",
    lastName: "",
    password: "",
    email: "",
    phoneNumber: "",
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
  },
  methods: {
    ...mapActions("userModule", ["getUser", "updateUser"]),
    async saveChanges() {
      const command = {
        id: this.authenticationResult.tokenOwner.id,
        name: this.name,
        lastName: this.lastName,
        password: this.password,
        email: this.email,
        phoneNumber: this.phoneNumber,
      };

      await this.updateUser(command);

      this.$emit("confirmed");
      this.$emit("canceled");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
};
</script>

<style scoped></style>
