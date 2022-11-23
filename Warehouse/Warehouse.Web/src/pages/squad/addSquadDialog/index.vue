<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card>
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Tworzenie Drużyny</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form" v-model="isValid">
            <v-text-field
              v-model="name"
              label="Nazwa drużyny"
              :rules="[(v) => !!v || 'Nazwa jest wymagana']"
            />
            <v-select
              v-model="selectedUser"
              label=" Drużynowy"
              :items="users"
              item-text="name"
              item-value="id"
              :rules="[(v) => !!v || 'Druzynowy jest wymagany']"
            ></v-select>
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
              Zapis
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
  name: "addSquadDialog",
  data: () => ({
    name: "",
    squadOwnerId: "",
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
    ...mapGetters("userModule", ["users"]),
  },
  methods: {
    ...mapActions("squadModule", ["addSquad"]),
    ...mapActions("userModule", ["getUsers"]),
    async saveChanges() {
      const command = {
        name: this.name,
        squadOwnerId: this.selectedUser,
      };

      await this.addSquad(command);

      this.$emit("confirmed");
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
