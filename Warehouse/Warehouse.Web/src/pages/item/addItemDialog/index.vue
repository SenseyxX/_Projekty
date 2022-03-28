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
          <!--ToDo: Add category combobox-->
          <v-select
            v-model="selectedCategory"
            label="Kategoria"
            :items="category"
            item-text="name"
            :rules="[(v) => !!v || 'Kategoria jest wymagana']"
            return-object
          ></v-select>
          <v-text-field v-model="quantity" label="Ilość" />
          <!--ToDo: Add quantityLevel combobox-->
          <v-select
            v-model="selectedQuantityLevel"
            label="Stan"
            :items="qualityLevel"
            item-text="name"
            item-value="id"
            :rules="[(v) => !!v || 'Określenie stanu jest wymagane']"
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
    selectedQuantityLevel: 2,
    selectedCategory: null,
    qualityLevel: [
      { id: 0, name: "Śmietnik" },
      { id: 1, name: "Zły" },
      { id: 2, name: "Umiarkowany" },
      { id: 3, name: "Dobry" },
      { id: 4, name: "Świetny" },
    ],
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
    ...mapGetters("categoryModule", ["category"]),
  },
  methods: {
    ...mapActions("itemModule", ["addItem"]),
    ...mapActions("categoryModule", ["getCategories"]),
    async saveChanges() {
      console.log(this.selectedQuantityLevel);
      const command = {
        name: this.name,
        description: this.description,
        categoryId: this.categoryId,
        qualityLevel: this.selectedQuantityLevel,
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
  async mounted() {
    await this.getCategories();
    console.log(this.category);
  },
};
</script>

<style scoped></style>
