<template>
  <section class="text-center centerized">
    <v-data-table :headers="headers" :items="items" item-key="id" />
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "ItemsTable",
  components: {},
  props: {
    itemId: {
      //ToDo: Change type, probably only id needed
      type: Object,
      defaultValue: null,
    },
  },
  data() {
    return {
      headers: [
        { text: "Nazwa", value: "name" },
        { text: "Opis", value: "description" },
        { text: "Kategoria", value: "categoryId" },
        { text: "Stan", value: "qualityLevel" },
        { text: "Ilośc", value: "quantity" },
        { text: "Właściciel", value: "ownerId" },
        { text: "Posiadacz", value: "actualOwnerId" },
      ],
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("userModule", ["items"]),
    // filteredUsers() {
    //   return this.users.filter((user) => user.teamId === team.id);
    // },
  },
  methods: {
    ...mapActions("itemModule", ["getItems"]),
  },

  async mounted() {
    await this.GetUserItems(this.authenticationResult.tokenOwner.id);
    console.log(this.GetUserItems(this.authenticationResult.tokenOwner.id));
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
