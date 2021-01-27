<template>
  <div class="ActiveVaultPage mt-5 container">
    <div class="row">
      <div class="col-12">
        <h1>{{ activeVault.name }}</h1>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h2>{{activeVault.description}}</h2>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h3>Keeps: {{ activeVaultKeeps.length }}</h3>
      </div>
    </div>
    <div class="card-columns p-0">
      <vault-keep v-for="vk in activeVaultKeeps" :key="vk.id" :vkprops="vk" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { vaultService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
export default {
  name: 'ActiveVaultPage',
  props: ['kprops'],
  components: { },
  setup(props) {
    const route = useRoute()
    onMounted(() => {
      vaultService.getOne(route.params.vaultId)
      vaultService.getVaultKeeps(route.params.vaultId)
    })
    return {
      userProfile: computed(() => AppState.user),
      activeVaultKeeps: computed(() => AppState.activeVaultKeeps),
      activeVault: computed(() => AppState.activeVault),
      deleteVault(id) {
        vaultService.deleteVault(id)
      }
    }
  }

}
</script>

<style scoped>
img {
  max-width: 100px;
}
h1 {
  font-weight: bold;
  font-size: 75px;
}
i {
  color: gray;
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
