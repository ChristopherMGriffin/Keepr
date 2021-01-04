<template>
  <div class="home flex-grow-1 d-flex align-items-center container-fluid">
    <div class="row mt-2">
      <v-masonry></v-masonry>
      <Keep v-for="keep in keeps" :key="keep.id" :kprops="keep" />
    </div>
  </div>
</template>

<script>
import { keepService } from '../services/KeepService'
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  props: ['kprops'],
  setup(props) {
    onMounted(() => {
      keepService.getAll()
    })
    return {
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps)

    }
  }
}

</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
}

</style>
