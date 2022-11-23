<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Usuwanie użytkownika</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form" v-model="isValid">
            <p class="body-4 text-muted subtitle">
              Czy jesteś pewien że chcesz usunąć tego użytkownika "{{ this.name }}"?
            </p>
          </v-form>
        </div>
        <v-container>
          <v-row class="buttons-group" justify="end">
            <v-btn @click="cancel" text color="primary" outlined class="mr-8">
              NIE
            </v-btn>
            <v-btn
              @click="deleteItem"
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
  name: "deleteUserDialog",
  watch: {
    user() {
      if (this.user === null) {
        return;
      }
      this.id = this.user.id;
      this.name = this.user.name;
    },
  },
  data: () => ({
    id: "",
    name: "",
    isValid: false,
  }),
  props: {
    user: {
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
    ...mapActions("userModule", ["deleteUser"]),
    async deleteItem() {
      console.log("Usunięto użytkowanika:");
      // console.log(this.name);
      // console.log(this.id);
      // await this.deleteUser(this.id);
      this.$emit("confirmed");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
  async mounted() {},
};
</script>

<style scoped></style>
