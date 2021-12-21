<template>
  <v-dialog persistent v-model="dialogVisibility">
    <v-card class="frame">
      <p class="ma-4 text-h6">Przedmioty</p>
      <div class="select-group">
        <v-form ref="form" v-model="isValid">
          <v-text-field
            v-model="name"
            label="Nazwa przedmiotu"
            :rules="[(v) => !!v || 'Nazwa jest wymagana']"
          />
          <v-text-field v-model="description" label="Opis przedmiotu" />
          <v-text-field
            v-model="categoryId"
            label="Kategoria przedmiotu"
            :rules="[(v) => !!v || 'Kategoria jest wymagana']"
          />
          <v-text-field
            v-model="qualityLevel"
            label="Jakość przedmiotu"
            :rules="[(v) => !!v || 'Jakość jest wymagana']"
          />
          <v-text-field
            v-model="quantity"
            label="Ilość"
            :rules="[(v) => !!v || 'Ilość jest wymagana']"
          />
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
  name: "addItemDialog",
  data: () => ({
    name: "",
    description: "",
    categoryId: "",
    qualityLevel: "",
    quantity: "1",
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
    ...mapActions("itemModule", ["addItem"]),
    async saveChanges() {
      const command = {
        name: this.name,
        description: this.description,
        categoryId: this.categoryId,
        qualityLevel: this.qualityLevel,
        quantity: this.quantity,
        ownerId: this.authenticationResult.tokenOwner.id,
      };

      await this.addItem(command);

      this.$emit("confirmed");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
};
</script>

<style scoped></style>
