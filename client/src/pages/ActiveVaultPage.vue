<template>
  <div class="ActiveVaultPage container-fluid p-5">
    <h1>{{ activeVault.name }} <i class="fa fa-trash fa-xs" aria-hidden="true"></i></h1>
    <h3>Keeps: {{ activeVaultKeeps.length }}</h3>
    <div class="card-columns p-3">
      <VaultKeepComponent v-for="vk in activeVaultKeeps" :key="vk.id" :vkprops="vk" />
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
  props: ['vkprops'],
  setup(props) {
    const route = useRoute()
    onMounted(() => {
      vaultService.getOne(route.params.vaultId)
    })
    return {
      profile: computed(() => AppState.activeProfile),
      activeVaultKeeps: computed(() => AppState.activeVaultKeeps),
      activeVault: computed(() => AppState.activeVault)
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
</style>
