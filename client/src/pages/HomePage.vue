<template>
  <div class="home flex-grow-1 d-flex align-items-center container-fluid">
    <div class="card-columns p-3">
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
@media (min-width: 12em) {
    .card-columns {
        -webkit-column-count: 2;
        -moz-column-count: 2;
        column-count: 2;
    }
}

@media (min-width: 48em) {
    .card-columns {
        -webkit-column-count: 3;
        -moz-column-count: 3;
        column-count: 3;
    }
}

@media (min-width: 62em) {
    .card-columns {
        -webkit-column-count: 4;
        -moz-column-count: 4;
        column-count: 4;
    }
}

@media (min-width: 75em) {
    .card-columns {
        -webkit-column-count: 5;
        -moz-column-count: 5;
        column-count: 5;
    }
}

</style>
