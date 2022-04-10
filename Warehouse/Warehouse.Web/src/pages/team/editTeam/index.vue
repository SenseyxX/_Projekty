<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card>
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Edycja zastępu</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form" v-model="isValid">
            <v-row>
              <v-text-field
                v-model="name"
                label="Nazwa zastępu"
                :rules="[(v) => !!v || 'Nazwa jest wymagana']"
              />
            </v-row>
            <v-row>
              <v-select
                v-model="selectedUser"
                label=" Zastępowy"
                :items="filteredUsers"
                item-text="name"
                item-value="id"
                :rules="[(v) => !!v || 'Druzynowy jest wymagany']"
              ></v-select>
            </v-row>
            <v-row>
              <v-slider
                v-model="team.points"
                class="align-center"
                :max="max"
                :min="min"
                hide-details
              >
                <template v-slot:append>
                  <v-text-field
                    v-model="team.points"
                    class="mt-0 pt-0"
                    hide-details
                    single-line
                    type="number"
                    style="width: 60px"
                  ></v-text-field>
                </template>
              </v-slider>
            </v-row>
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
  name: "addSquadDialog",
  data: () => ({
    min: 0,
    max: 200,
    slider: 40,
    name: "",
    squadOwnerId: "",
    isValid: false,
    selectedUser: null,
  }),
  props: {
    selectedteam: {
      type: Object,
      defaultValue: null,
    },
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
    ...mapGetters("squadModule", ["team"]),
    filteredUsers() {
      return this.users.filter(
        (users) => users.squadId === this.selectedteam.squadId
      );
    },
  },
  methods: {
    ...mapActions("userModule", ["getUsers"]),
    ...mapActions("squadModule", ["getSquadTeams"]),
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
    await this.getSquadTeams(this.selectedteam.id);
  },
};
</script>

<style scoped></style>
