<template>
  <v-footer app :color="Theme.containerBackgroundColor" class="info-bar">
    <div class="column">
      <span class="logo coloured"> {{ Names.applicationName }} </span>
      <div class="info-bar_detail">
        <span class="detail-label"> WERSJA 1.0.0 </span>
        <span class="detail-label">OSTATNIA AKTUALIZACJA: 05.11.2023 </span>
      </div>
    </div>
    <div>
      <span class="mr-5 detail-label">&copy;2023 OG SOLUTIONS</span>
    </div>
  </v-footer>
</template>

<script>
import { Theme, Names } from "@/shared/constants";

export default {
  data: () => ({
    Theme,
    Names,
    aboutDialogVisibility: false,
  }),
  components: {},
  computed: {},
  methods: {},
  async mounted() {},
};
</script>

<style lang="scss" scoped>
@import "@/assets/styles/_colors.scss";
@import "@/assets/styles/index.scss";
.info-bar {
  display: flex;
  align-items: center;
  justify-content: space-between;
  font-size: 10px;

  .info-bar_detail {
    margin-top: 4px;
  }

  .detail-label {
    margin: 0 10px 0 10px;
    color: DarkGray;
  }

  .column {
    display: flex;
    align-items: center;
    justify-content: center;

    & > * {
      color: lightGray;

      &:not(:last-child) {
        margin-right: 16px;
      }
    }
    .coloured {
      color: $darkBlue;
    }
  }
}
</style>
