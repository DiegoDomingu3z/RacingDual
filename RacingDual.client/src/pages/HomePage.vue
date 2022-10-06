<template>
  <div class="img">
    <HomeTop />
  </div>
</template>


<script>
import { onMounted, computed } from '@vue/runtime-core'
import { formulaOneService } from '../services/FormulaOneService'
import { AppState } from '../AppState'
import HomeTop from '../components/Home/HomeTop.vue'
import MobileNavbar from '../components/MobileView/MobileNavbar.vue'
export default {
  setup() {
    onMounted(async () => {
      try {
        await formulaOneService.getCurrentSeasonSchedule();
      }
      catch (error) {
      }
    });
    return {
      f1: computed(() => AppState.f1)
    };
  },
  components: { HomeTop }
}
</script>


<style lang="scss" scoped>
.img {
  background-image: url("https://images.unsplash.com/flagged/photo-1557050688-a224243c012f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80");
  height: 50vh;
  width: 100%;
  background-position: center;
  background-size: cover;
}
</style>
