<template>
  <div>
    {{ f1 }}
  </div>
</template>


<script>
import { onMounted, computed } from '@vue/runtime-core'
import { formulaOneService } from '../services/FormulaOneService'
import { AppState } from '../AppState'
export default {
  setup() {
    onMounted(async () => {
      try {
        await formulaOneService.getCurrentSeasonSchedule()
      } catch (error) {

      }
    })
    return {
      f1: computed(() => AppState.f1)

    }
  }
}
</script>


<style lang="scss" scoped>
</style>
