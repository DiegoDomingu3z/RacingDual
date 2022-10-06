<template>
  <button
    class="sign-in-btn selectable my-2 my-lg-0"
    @click="login"
    v-if="!user.isAuthenticated"
  >
    Sign in
  </button>
  <button
    class="sign-up-btn selectable my-2 my-lg-0"
    @click="login"
    v-if="!user.isAuthenticated"
  >
    Sign up
  </button>

  <div class="dropdown my-lg-0" v-else>
    <div
      class="dropdown-toggle selectable"
      data-bs-toggle="dropdown"
      aria-expanded="false"
      id="authDropdown"
    >
      <div v-if="account.picture || user.picture">
        <img
          :src="account.picture || user.picture"
          alt="account photo"
          height="40"
          class="rounded"
        />
      </div>
      <!-- <span class="mx-3 text-success lighten-30">{{ account.name || user.name }}</span> -->
    </div>
    <div
      class="dropdown-menu p-0 list-group w-100"
      aria-labelledby="authDropdown"
    >
      <router-link :to="{ name: 'Account' }">
        <div class="list-group-item list-group-item-action hoverable">
          Manage Account
        </div>
      </router-link>
      <div
        class="list-group-item list-group-item-action hoverable text-danger"
        @click="logout"
      >
        <i class="mdi mdi-logout"></i>
        logout
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import { AuthService } from "../services/AuthService";
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup();
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin });
      },
    };
  },
};
</script>


<style lang="scss" scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}

.sign-in-btn {
  display: inline-block;
  padding: 0.46em 1.6em;
  background-color: #e10600;
  border: 0.1em solid #000000;
  margin: 0 0.2em 0.2em 0;
  border-radius: 0.12em;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-weight: 300;
  text-shadow: 0 0.04em 0.04em rgba(0, 0, 0, 0.35);
  text-align: center;
  transition: all 0.15s;
}

.sign-in-btn:hover {
  text-shadow: 0 0 2em rgba(255, 255, 255, 1);
  color: #ffffff;
  transition: 400ms;
  border: 0.12em solid #000000;
}

.sign-up-btn {
  padding: 0.3rem;
  border-radius: 15%;
  margin-right: 0.8rem;
}
</style>
