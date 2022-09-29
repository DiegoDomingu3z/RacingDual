<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-danger px-3">
    <div>
      <router-link :to="{ name: 'Home' }">
        <img class="img-fluid img" src="../assets/img/RD-logo.jpg" alt="" />
      </router-link>
    </div>
    <router-link :to="{ name: 'MainFeed' }">go to main feed</router-link>
    <div>
      <Login />
    </div>
  </nav>
</template>

<script>
import { computed } from '@vue/runtime-core';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';

export default {
  setup() {
    return {

    };

  },
};
</script>

<style scoped>
a:hover {
  text-decoration: none;
}
.nav-link {
  text-transform: uppercase;
}
.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.img {
  height: 90px;
  width: 90px;
  border-radius: 50%;
}
</style>
