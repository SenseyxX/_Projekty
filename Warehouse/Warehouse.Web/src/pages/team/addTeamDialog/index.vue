<template>
  <v-dialog persistent v-model="dialogVisibility">
    <v-card class="frame">
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Zastępy</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form" v-model="isValid">
            <v-text-field
              v-model="name"
              label="Nazwa Zastępu"
              :rules="[(v) => !!v || 'Nazwa jest wymagana']"
            />
            <!--ToDo: Add combobox to teamOwner with ppl with squadId same like squadOwner-->
            <v-select
              v-model="selectedUser"
              :items="teams"
              item-text="name"
              return-object
            ></v-select>
            <v-text-field v-model="teamOwnerId" label="Zastępowy" />
            <v-text-field v-model="description" label="Opis zastępu" />
          </v-form>
        </div>
      </v-card-text>
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
  },
  methods: {
    ...mapActions("squadModule", ["addTeam"]),

    async saveChanges() {
      const command = {
        name: this.name,
        teamOwnerId: this.teamOwnerId,
        description: this.description,
        points: this.points,
        squadId: this.authenticationResult.tokenOwner.squadId,
      };

      await this.addTeam(command);

      this.$emit("confirmed");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
  async mounted() {
    // ToDo: Add getting of users.
  },
};
</script>

<style scoped></style>
