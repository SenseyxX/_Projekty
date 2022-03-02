<template>
  <section class="text-center centerized">
    <squad-list />
  </section>
</template>

<script>
import SquadList from "@/pages/squad/squadList";

export default {
  name: "SquadPage",
  components: {
    SquadList,
  },
  data() {
    return {
      addSquadDialogVisibility: false,
    };
  },
  computed: {},
  methods: {},
  async mounted() {},
};
</script>

<style scoped>
.centerized {
  margin-top: 75px;
}

.text-label {
  margin: 5vh 1vw 1vw;
  max-width: 250px;
  min-width: 200px;
}

.page-button {
  height: 40px;
  min-width: 400px;
  color: white;
}
</style>
