<template>
  <section class="text-center centerized">
    <v-row>
      <v-col md="3">
        <v-text-field
          v-model="search"
          append-icon="mdi-magnify"
          label="Szukaj"
          single-line
          hide-details
        ></v-text-field>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-data-table
          :headers="headers"
          :items="filteredTeams"
          :search="search"
          item-key="id"
        ></v-data-table>
      </v-col>
    </v-row>
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "TeamTable",
  components: {},
  props: {
    selectedsquad: {
      type: Object,
      defaultValue: null,
    },
  },
  data() {
    return {
      search: "",
      headers: [
        { text: "Nazwa", value: "name" },
        { text: "Drużyna", value: "squadName" },
        { text: "Zastępowy", value: "teamOwnerName" },
        { text: "Punkty", value: "points" },
      ],
    };
  },
  computed: {
    ...mapGetters("squadModule", ["teams"]),
    ...mapGetters("userModule", ["users"]),
    filteredTeams() {
      return this.teams.filter(
        (teams) => teams.squadId === this.selectedsquad.id
      );
    },
  },
  methods: {
    ...mapActions("squadModule", ["getSquadTeams"]),
    ...mapActions("userModule", ["getUsers"]),
    userName(squadOwnerId) {
      const user = this.users.find((user) => user.id === squadOwnerId);
      return user.name + " " + user.lastName;
    },
  },

  async mounted() {
    await this.getSquadTeams(this.selectedsquad.id);
    await this.getUsers();
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
