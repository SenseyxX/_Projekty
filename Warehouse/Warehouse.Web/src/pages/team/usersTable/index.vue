<template>
  <section class="text-center centerized">
    <v-data-table
      :headers="headers"
      :items="users"
      item-key="id"
    ></v-data-table>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "UserTable",
  components: {},
  props: {
    team: {
      type: Object,
      defaultValue: null,
    },
  },
  data() {
    return {
      headers: [
        { text: "Imię", value: "name" },
        { text: "Nazwisko", value: "lastName" },
        { text: "E-mail", value: "email" },
        { text: "Telefon", value: "phoneNumber" },
      ],
    };
  },
  computed: {
    ...mapGetters("userModule", ["users"]),
    // filteredUsers() {
    //   return this.users.filter((user) => user.teamId === team.id);
    // },
  },
  methods: {
    ...mapActions("userModule", ["getUsers"]),
  },

  async mounted() {
    await this.getUsers();
    console.log(this.users);
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
