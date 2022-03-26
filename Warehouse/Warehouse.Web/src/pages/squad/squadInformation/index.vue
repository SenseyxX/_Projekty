<template>
  <section class="text-center centerized">
    <v-list readonly>
      <v-list-item>Nazwa: {{ squad.name }}</v-list-item>
      <v-list-item>Zastępowy: {{ squad.teamOwnerId }}</v-list-item>
    </v-list>
  </section>
</template>

<script>
export default {
  name: "SquadInformation",
  components: {},
  props: {
    squad: {
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
