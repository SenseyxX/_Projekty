<template>
  <v-dialog persistent v-model="dialogVisibility" max-width="650">
    <v-card class="frame">
      <v-toolbar color="primary" dark>
        <p class="ma-4 text-h6">Dodawanie kategorii przedmiotów</p>
      </v-toolbar>
      <v-card-text>
        <div class="select-group">
          <v-form ref="form" v-model="isValid">
            <v-text-field
              v-model="name"
              label="Nazwa przedmiotu"
              :rules="[(v) => !!v || 'Nazwa jest wymagana']"
            />
            <v-text-field v-model="description" label="Opis kategorii" />
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
  name: "addCategoryDialog",
  data: () => ({
    name: "",
    description: "",
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
    ...mapGetters("categoryModule", ["category"]),
  },
  methods: {
    ...mapActions("categoryModule", ["addCategory"]),
    async saveChanges() {
      const command = {
        name: this.name,
        description: this.description,
      };
      console.log(command);
      await this.addCategory(command);

      this.$emit("confirmed");
      this.$emit("canceled");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
  async mounted() {},
};
</script>

<style scoped></style>
