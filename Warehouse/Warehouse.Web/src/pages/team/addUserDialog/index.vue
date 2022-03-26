<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <p class="ma-4 text-h6">Dodawanie użytkownika do zastępu</p>
      <div class="select-group"></div>
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
  name: "addUserTeamDialog",
  data: () => ({
    name: "",
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
    ...mapActions("squadModule", ["addUquad"]),
    async saveChanges() {
      const command = {
        name: this.name,
        squadOwnerId: this.authenticationResult.tokenOwner.id,
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
