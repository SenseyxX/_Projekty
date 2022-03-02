<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <p class="ma-4 text-h6">Skład</p>
      <div class="select-group">
        <v-form ref="form" v-model="isValid">
          <v-text-field
            v-model="name"
            label="Imię"
            :rules="[(v) => !!v || 'Imię jest wymagane']"
          />
          <v-text-field
            v-model="lastName"
            label="Nazwisko"
            :rules="[(v) => !!v || 'Nazwisko jest wymagane']"
          />
          <v-text-field
            v-model="password"
            type="password"
            label="Hasło"
            :rules="[
              (v) => !!v || 'Hasło jest wymagane',
              (v) => v.length >= 4 || 'Hasło jest za krótkie',
            ]"
          />
          <v-text-field
            v-model="email"
            label="E-mail"
            :rules="[(v) => !!v || 'Email jest wymagany']"
          />
          <v-text-field
            v-model="phoneNumber"
            label="Numer telefonu"
            :rules="[(v) => !!v || 'Numer telefonu jest wymagany']"
          />
        </v-form>
      </div>
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
  name: "registrationUserDialog",
  data: () => ({
    name: "",
    lastName: "",
    password: "",
    email: "",
    phoneNumber: "",
    isValid: false,
  }),
  props: {
    dialogVisibility: {
      type: Boolean,
      defaultValue: false,
    },
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
  },
  methods: {
    ...mapActions("registrationModule", ["addUser"]),
    async saveChanges() {
      const command = {
        name: this.name,
        lastName: this.lastName,
        password: this.password,
        email: this.email,
        phoneNumber: this.phoneNumber,
      };

      await this.addUser(command);

      this.$emit("confirmed");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
};
</script>

<style scoped></style>
