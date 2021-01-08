<template>
  <li class="VaultMenuComponent col-12">
    <router-link :to="{ name: 'ActiveVault', params: { vaultId: vprops.id} }">
      <button
        type="button"
        class="btn btn-sm btn-lg btn-link"
        @click="addToVault(vprops.id)"
        data-dismiss="modal"
      >
        <p>{{ vprops.name }}</p>
      </button>
    </router-link>
  </li>
</template>

<script>
import { computed, reactive } from 'vue'
import { vaultService } from '../services/VaultsService'
import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
export default {
  name: 'VaultMenuComponent',
  props: ['vprops', 'kprops'],
  setup(props) {
    const state = reactive({
      newVk: {}
    })
    return {
      state,
      profileVaults: computed(() => AppState.profileVaults),
      activeVault: computed(() => AppState.activeVault),

      addToVault(vId) {
        logger.log('vid', vId)
        vaultService.createVaultKeep(vId)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
