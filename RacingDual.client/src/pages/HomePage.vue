<template>
  <div class="img"></div>
  <div class="img"></div>
  <div class="img"></div>
</template>


<script>
import { onMounted, computed } from '@vue/runtime-core'
import { formulaOneService } from '../services/FormulaOneService'
import { AppState } from '../AppState'
import HomeTop from '../components/Home/HomeTop.vue'
import MobileNavbar from '../components/MobileView/MobileNavbar.vue'
export default {
  setup() {
    var navbar = document.getElementById("navbar")
    var sticky = navbar.offsetTop
    onMounted(async () => {
      try {
        await formulaOneService.getCurrentSeasonSchedule();
        window.onscroll = function () { myFunction() }
      }
      catch (error) {

      }
    });
    return {
      myFunction() {
        if (window.pageYOffset >= sticky) {
          navbar.classList.add("sticky")
        } else {
          navbar.classList.remove("sticky");
        }
      },
      f1: computed(() => AppState.f1)

    };
  },
  components: { HomeTop }
}
</script>


<style lang="scss" scoped>
.img {
  background-image: url("https://images.unsplash.com/photo-1593693044238-f14e5b164e75?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2832&q=80");
  height: 50vh;
  width: 100%;
  background-position: center;
  background-size: cover;
}
</style>
