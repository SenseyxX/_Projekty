<template>
  <section class="text-center centerized">
    <h6 class="title">Zaloguj się</h6>
    <p class="body-2 text-muted subtitle">
      Wpisz poniżej swój login i hasło a następnie nacisnij "Zaloguj".
    </p>
    <v-btn text color="primary" @click="showRegistrationUserDialog"
      >Zarejestruj</v-btn
    >
    <v-form v-model="isValid">
      <v-row justify="center" dense class="ml-3 mr-3">
        <v-text-field
          required
          class="text-label"
          label="Login"
          name="login"
          v-model="loginValue"
          :rules="[(value) => !!value || 'Wpisz login']"
        />
        <div />
        <v-text-field
          required
          name="password"
          class="text-label"
          label="Hasło"
          type="password"
          v-model="passwordValue"
          :rules="[(value) => !!value || 'Wpisz hasło']"
        />
      </v-row>
    </v-form>
    <v-row class="fill-height" justify="center">
      <v-btn
        class="page-button"
        @click="onClick()"
        :color="Theme.mainButtonBackgroundColor"
        :disabled="!isValid"
      >
        Zaloguj
      </v-btn>
    </v-row>
    <registration-user-dialog
      :dialog-visibility="registrationUserDialogVisibility"
      @canceled="hideRegistrationUserDialog"
    />
  </section>
</template>

<script>
import { Theme } from "@/shared/constants";
import { mapGetters, mapActions } from "vuex";
import registrationUserDialog from "./registrationUserDialog";

export default {
  name: "LoginPage",
  components: {
    registrationUserDialog,
  },
  data() {
    return {
      loginValue: "",
      passwordValue: "",
      registrationUserDialogVisibility: false,
      Theme,
      isValid: false,
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("registrationModule", ["user"]),
  },
  methods: {
    ...mapActions("authenticationModule", ["authenticate"]),
    ...mapGetters("registrationModule", ["addUser"]),
    async onClick() {
      const command = {
        email: this.loginValue,
        password: this.passwordValue,
      };

      await this.authenticate(command);
      await this.$router.push("/item");
    },
    showRegistrationUserDialog() {
      this.registrationUserDialogVisibility = true;
    },
    hideRegistrationUserDialog() {
      this.registrationUserDialogVisibility = false;
    },
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}

.text-label {
  margin: 5vh 1vw 1vw;
  max-width: 250px;
  min-width: 200px;
}

.page-button {
  height: 40px;
  min-width: 400px;
  color: white;
}
</style>
