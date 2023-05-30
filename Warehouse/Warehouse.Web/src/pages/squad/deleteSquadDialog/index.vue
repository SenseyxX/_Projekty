<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Usuwanie Druzyny</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form" v-model="isValid">
            <p class="body-4 text-muted subtitle">
              Czy jesteś pewien że chcesz usunąć tą drużynę "{{ name }}"?
            </p>
          </v-form>
        </div>
        <v-container>
          <v-row class="buttons-group" justify="end">
            <v-btn @click="cancel" text color="primary" outlined class="mr-8">
              NIE
            </v-btn>
            <v-btn
              @click="confirmSquad"
              color="primary"
              class="mr-8"
              :disabled="!isValid"
            >
              TAK
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
  name: "deleteSquadDialog",
  data: () => ({
    id: "",
    name: "",
    isValid: false,
  }),
  props: {
    squad: {
      type: Object,
      defaultValue: {},
    },
    dialogVisibility: {
      type: Boolean,
      defaultValue: false,
    },
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
  },
  methods: {
    ...mapActions("squadModule", ["deleteSquad"]),
    async confirmSquad() {
      await this.deleteSquad(this.id);
      this.$emit("confirmed");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
  async mounted() {
    this.id = this.squad.id;
    this.name = this.squad.name;
  },
};
</script>

<style scoped></style>