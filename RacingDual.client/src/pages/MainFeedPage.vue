<template>
  <div>yooo</div>
</template>


<script>
import { onMounted } from '@vue/runtime-core'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { postFeedService } from '../services/postFeedService'
export default {
  setup() {
    onMounted(async () => {
      try {
        await postFeedService.getAllPosts()
      } catch (error) {
        logger.log(error.message)
      }
    })
    return {

    }
  }
}
</script>


<style lang="scss" scoped>
</style>