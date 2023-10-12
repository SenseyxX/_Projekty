<template>
  <v-dialog
    persistent
    v-model="dialogVisibility"
    max-width="650"
    max-height="800"
  >
    <v-card class="frame">
      <v-toolbar color="primary" dark>
        <p class="text-h6">Przypisywanie użytkowników do zastępu</p>
      </v-toolbar>
      <v-card-text class="body">
        <div class="users-table">
          <div v-for="item in usersNotInSquad" :key="item.id">
            <v-simple-checkbox v-model="item.IsSelected"></v-simple-checkbox>
            {{ item.Name }}
          </div>
        </div>
        <div class="arrows">
          <div class="center">
            <v-btn class="primary mb-2" dark @click="onRightArrowClick">
              <v-icon dark>mdi-arrow-right-circle</v-icon>
            </v-btn>
            <v-btn class="primary">
              <v-icon dark>mdi-arrow-left-circle</v-icon>
            </v-btn>
          </div>
        </div>
        <v-list class="users-table">
          <v-list-item-group color="primary" dark>
            <v-list-item v-for="item in usersInSquad" :key="item.id">
              <v-simple-checkbox v-model="item.IsSelected"></v-simple-checkbox>
              {{ item.Name }}
            </v-list-item>
          </v-list-item-group>
        </v-list>
      </v-card-text>
      <v-card-actions class="justify-end">
        <v-btn @click="cancel" text color="primary" outlined class="mr-2">
          Anuluj
        </v-btn>
        <v-btn
          @click="saveChanges"
          color="primary"
          class="mr-2 mb-1"
          :disabled="!isValid"
        >
          Zapisz
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "assignUserDialog",
  data: () => ({
    userId: "",
    name: "",
    teamId: "",
    isValid: false,
    usersInSquad: [
      { Id: 1, Name: "Oskar Gacki", IsSelected: false },
      { Id: 2, Name: "Piort Gacki", IsSelected: false },
      { Id: 3, Name: "Oskar Nowak", IsSelected: false },
      { Id: 4, Name: "Olek Janek", IsSelected: false },
    ],
    usersNotInSquad: [
      { Id: 5, Name: "Bolek Dumbo", IsSelected: false },
      { Id: 6, Name: "Lolek Dumbo", IsSelected: false },
      { Id: 7, Name: "Bilbo Baggins", IsSelected: false },
      { Id: 8, Name: "Testowy User", IsSelected: false },
    ],
    selectedLeft: [],
  }),
  props: {
    dialogVisibility: {
      type: Boolean,
      defaultValue: false,
    },
    selectedTeam: {
      type: Object,
      defaultValue: false,
    },
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
  },
  methods: {
    ...mapActions("userModule", ["getUsers", "updateUser"]),
    //ToDo: add PUT user Endpoint
    //ToDo: add method to filter chosen team
    onRightArrowClick() {
      let removedItems = [];

      for (let i = this.usersNotInSquad.length - 1; i >= 0; i--) {
        console.log("Index", i);
        if (this.usersNotInSquad[i].IsSelected) {
          this.usersNotInSquad[i].IsSelected = false;
          removedItems.push(this.usersNotInSquad[i]);
          this.usersNotInSquad.splice(i, 1);
        }
      }

      this.usersInSquad = [...this.usersInSquad, ...removedItems];
    },
    async saveChanges() {
      const command = {
        id: this.userId,
        name: this.name,
        teamId: this.selectedTeam.id,
      };

      await this.up(command);

      this.$emit("confirmed");
      this.$emit("canceled");
    },
    cancel() {
      this.$emit("canceled");
    },
  },
};
</script>

<style scoped>
.body {
  display: flex;
  flex-direction: row;
  height: 400px;
  max-height: 400px;
}

.users-table {
  flex-grow: 2;
  margin: 1px;
  background-color: #1d3453;
  overflow-y: scroll;
}

.arrows {
  flex-grow: 1;
  margin: 1px;
  background-color: #37b34a;
  justify-content: center;
}

.center {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  min-height: 100%;
  background-color: #041e41;
}

.arrow {
  width: 50px;
  height: 50px;
}
</style>