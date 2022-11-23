<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card>
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Edytowanie Drużyny</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form" v-model="isValid">
            <v-text-field v-model="name" label="Nowa nazwa drużyny" />
            <v-select
              v-model="selectedUser"
              label="Nowy Drużynowy"
              :items="users"
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
  name: "editSquadDialog",
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
    selectedSquad: {
      type: Object,
      defaultValue: null,
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
    ...mapGetters("squadModule", ["squad"]),
  },
  methods: {
    ...mapActions("squadModule", ["updateSquad"]),
    async saveChanges() {
      const command = {
        name: this.name,
        squadOwnerId: this.selectedUser,
      };

      await this.updateSquad(command);
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
