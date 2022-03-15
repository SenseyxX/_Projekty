<template>
  <section class="text-center centerized">
    <v-list readonly>
      <v-list-item>Nazwa: {{ team.name }}</v-list-item>
      <v-list-item>Zastępowy: {{ team.teamOwnerId }}</v-list-item>
      <v-list-item>Punkty: {{ team.points }}</v-list-item>
    </v-list>
  </section>
</template>

<script>
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
  methods: {},
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
