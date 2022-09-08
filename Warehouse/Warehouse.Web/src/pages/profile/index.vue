<template>
  <section class="text-center centerized">
    <div>
      <v-list readonly>
        <v-list-item>Imię: {{ user.name }}</v-list-item>
        <v-list-item>Nazwisko: {{ user.lastName }}</v-list-item>
        <v-list-item>E-mail: {{ user.email }}</v-list-item>
        <v-list-item>Telefon: {{ user.phoneNumber }}</v-list-item>
        <v-list-item>Drużyna: {{ squadName(user.squadId) }}</v-list-item>
        <v-list-item>Zastęp: {{ user.teamId }}</v-list-item>
      </v-list>
    </div>
    <div>
      <v-btn color="primary" @click="showEditProfileDialog"
        >Edytuj Profil</v-btn>      
    </div>
    <edit-profile-dialog
      :dialog-visibility="editProfileDialogVisibility"
      @canceled="hideEditProfileDialog"
    />
  </section>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import EditProfileDialog from "@/pages/profile/editProfileDialog";

export default {
  name: "ProfilePage",
  components: { EditProfileDialog },
  data() {
    return {
      editProfileDialogVisibility: false,
    };
  },
  computed: {
    ...mapGetters("authenticationModule", ["authenticationResult"]),
    ...mapGetters("userModule", ["user"]),
    ...mapGetters("squadModule", ["squads"]),
    ...mapGetters("squadModule", ["teams"]),
  },
  methods: {
    ...mapActions("authenticationModule", ["authenticate"]),
    ...mapActions("userModule", ["getUser"]),
    ...mapActions("squadModule", ["getSquadTeams"]),
    ...mapActions("squadModule", ["getSquads"]),
    squadName(squadId) {
      const squad = this.squads.find((squad) => squad.id === squadId);
      if (squad) {
        return squad.name;
      }

      return "";
    },
    showEditProfileDialog() {
      this.editProfileDialogVisibility = true;
    },
    hideEditProfileDialog() {
      this.editProfileDialogVisibility = false;
    },
  },
  async mounted() {
    await this.getUser(this.authenticationResult.tokenOwner.id);
    await this.getSquads();
  },
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
