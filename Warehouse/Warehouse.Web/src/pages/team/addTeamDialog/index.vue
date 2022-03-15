<template>
  <v-dialog persistent v-model="dialogVisibility">
    <v-card class="frame">
      <p class="ma-4 text-h6">Zastępy</p>
      <div class="select-group">
        <v-form ref="form" v-model="isValid">
          <v-text-field
            v-model="name"
            label="Nazwa Zastępu"
            :rules="[(v) => !!v || 'Nazwa jest wymagana']"
          />
          <!--ToDo: Add combobox to teamOwner with ppl with squadId same like squadOwner-->
          <v-text-field v-model="teamOwnerId" label="Zastępowy" />
          <v-text-field v-model="description" label="Opis zastępu" />
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
  name: "addTeamDialog",
  data: () => ({
    name: "",
    teamOwnerId: "",
    description: "",
    points: "0",
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
};
</script>

<style scoped></style>
