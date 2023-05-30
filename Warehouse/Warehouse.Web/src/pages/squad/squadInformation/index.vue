<template>
  <section class="text-center centerized">
    <v-list readonly>
      <v-list-item>Nazwa: {{ selectedsquad.name }}</v-list-item>
      <v-list-item
        >Drużynowy: {{ userName(selectedsquad.squadOwnerId) }}</v-list-item
      >
    </v-list>
  </section>
</template>

<script>
import { mapActions, mapGetters } from "vuex";

export default {
  name: "SquadInformation",
  components: {},
  props: {
    selectedsquad: {
      type: Object,
      defaultValue: {},
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

      if (user) {
        return user.name + " " + user.lastName;
      }
      return "";
    },
  },
  async mounted() {
    await this.getUsers();
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>