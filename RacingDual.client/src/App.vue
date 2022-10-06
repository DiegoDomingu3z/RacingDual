<template>
  <header>
    <Navbar class="desktop-nav" />
    <MobileNavbar />
  </header>
  <main class="bg-white">
    <router-view />
  </main>
</template>

<script>
import { computed } from 'vue';
import { AppState } from './AppState';
import MobileNavbar from './components/MobileView/MobileNavbar.vue';

export default {
  name: "App",
  setup() {
    return {
      appState: computed(() => AppState)
    };
  },
  components: { MobileNavbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

@media (max-width: 780px) {
  .desktop-nav {
    display: none;
  }
}
</style>
