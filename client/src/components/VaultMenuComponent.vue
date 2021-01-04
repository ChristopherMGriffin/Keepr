<template>
  <li class="VaultMenuComponent col-12">
    <button type="button" class="btn btn-sm btn-lg btn-link" @click="addToVault(vprops.id)" data-toggle="dropdown">
      <p>{{ vprops.name }}</p>
    </button>
  </li>
</template>

<script>
import { computed } from 'vue'
import { vaultsService } from '../services/VaultsService'
import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
export default {
  name: 'VaultMenuComponent',
  props: ['vprops'],
  setup(props) {
    return {
      activeProduct: computed(() => AppState.activeProduct),
      addToVault(vId) {
        logger.log('vid', vId, 'activeProductId', this.activeProduct.id)
        vaultsService.addToWishlist(vId, this.activeProduct.id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
</style>
