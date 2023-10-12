<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card>
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Rejestracja</p>
      </v-toolbar>
      <v-card-text>
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
            <!--            <v-select-->
            <!--              v-model="selectedSquad"-->
            <!--              label=" Drużyna"-->
            <!--              :items="squads"-->
            <!--              item-text="name"-->
            <!--              item-value="id"-->
            <!--              :rules="[(v) => !!v || 'Drużyna jest wymagany']"-->
            <!--            ></v-select>-->
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
      </v-card-text>
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
    squad: "",
    isValid: false,
    selectedSquad: null,
  }),
  props: {
    dialogVisibility: {
      type: Boolean,
      defaultValue: false,
    },
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("squadModule", ["squads"]),
  },
  watch: {
    dialogVisibility() {
      if (this.dialogVisibility === true) {
        this.clean();
      }
    },
  },
  methods: {
    ...mapActions("registrationModule", ["addUser"]),
    ...mapActions("squadModule", ["getSquads"]),
    async saveChanges() {
      const command = {
        name: this.name,
        lastName: this.lastName,
        password: this.password,
        email: this.email,
        phoneNumber: this.phoneNumber,
        squadId: this.selectedSquad,
      };

      await this.addUser(command);

      this.$emit("confirmed");
      this.$emit("canceled");
    },
    cancel() {
      this.$emit("canceled");
    },
    clean() {
      this.name = "";
      this.lastName = "";
      this.password = "";
      this.email = "";
      this.phoneNumber = "";
      this.squad = "";
      this.isValid = false;
      this.selectedSquad = null;

      this.$refs.form.resetValidation();
    },
  },
};
</script>