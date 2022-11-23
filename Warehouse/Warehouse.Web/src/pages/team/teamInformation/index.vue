<template>
  <section class="text-center centerized">
    <v-list readonly>
      <v-list-item>Nazwa: {{ team.name }}</v-list-item>
      <v-list-item>Zastępowy: {{ userName(team.teamOwnerId) }}</v-list-item>
      <v-list-item>Punkty: {{ team.points }}</v-list-item>
      <v-list-item>Opis: {{ team.description }}</v-list-item>
    </v-list>
  </section>
</template>

<script>
import { mapActions, mapGetters } from "vuex";

export default {
  name: "TeamInformation",
  components: {},
  props: {
    team: {
      type: Object,
      defaultValue: null,
    },
  },
  data() {
    return {};
  },
  computed: {
    ...mapGetters("userModule", ["users"]),
  },
  methods: {
    ...mapActions("userModule", ["getUsers"]),
    userName(squadOwnerId) {
      const user = this.users.find((user) => user.id === squadOwnerId);
      return user.name + " " + user.lastName;
    },

    async mounted() {
      await this.getUsers();
    },
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
