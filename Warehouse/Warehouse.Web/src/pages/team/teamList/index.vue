<template>
  <section class="text-center centerized">
    <v-list>
      <v-list-item-group v-model="selectedTeam" color="primary">
        <v-list-item v-for="item in teams" :key="item.id" :value="item">
          {{ item.name }}
        </v-list-item>
      </v-list-item-group>
    </v-list>
  </section>
</template>

<script>
import { mapGetters } from "vuex";

export default {
  name: "TeamList",
  data() {
    return {
      addTeamDialogVisibility: false,
      selectedTeam: null,
    };
  },
  watch: {
    selectedTeam() {
      if (this.selectedTeam) {
        this.$emit("teamSelected", this.selectedTeam);
        console.log(this.selectedTeam());
      }
    },
  },
  computed: {
    ...mapGetters("squadModule", ["teams"]),
  },
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}
</style>
