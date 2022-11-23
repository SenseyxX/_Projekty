<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Tworzenie Zastępu</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form" v-model="isValid">
            <v-text-field
              v-model="name"
              label="Nazwa Zastępu"
              :rules="[(v) => !!v || 'Nazwa jest wymagana']"
            />
            <v-select
              v-model="selectedUser"
              label=" Zastępowy"
              :items="filteredUser()"
              item-text="name"
              item-value="id"
              :rules="[(v) => !!v || 'Zastępowy jest wymagany']"
            ></v-select>
            <v-text-field v-model="description" label="Opis zastępu" />
          </v-form>
        </div>
        <v-card-actions justify="end">
          <v-container>
            <v-row class="buttons-group">
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
        </v-card-actions>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "addTeamDialog",
  data: () => ({
    name: "",
    teamOwnerId: "",
    description: "",
    points: "0",
    isValid: false,
    selectedUser: null,
  }),
  props: {
    dialogVisibility: {
      type: Boolean,
      defaultValue: false,
    },
  },
  watch: {
    selectedUser() {
      console.log(this.selectedUser);
    },
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("squadModule", ["teams"]),
    ...mapGetters("userModule", ["users"]),
  },
  methods: {
    ...mapActions("squadModule", ["addTeam"]),
    ...mapActions("userModule", ["getUsers"]),
    filteredUser() {
      return this.users.filter(
        (users) =>
          users.squadId === this.authenticationResult.tokenOwner.squadId
      );
    },

    async saveChanges() {
      const command = {
        name: this.name,
        teamOwnerId: this.selectedUser,
        description: this.description,
        squadId: this.authenticationResult.tokenOwner.squadId,
      };

      await this.addTeam(command);

      this.$emit("confirmed");
      this.$emit("canceled");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
  async mounted() {
    await this.getUsers();
  },
};
</script>

<style scoped></style>
