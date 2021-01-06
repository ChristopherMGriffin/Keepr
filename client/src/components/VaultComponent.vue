<template>
  <div class="m-1 VaultComponent">
    <!--Card image-->
    <router-link :to="{ name: 'ActiveVault', params: { vaultId: vprops.id} }">
      <div class="col container p-0">
        <img class="card-img" src="../assets/img/vaultPhoto.jpeg" alt="">
        <div class="card-img-overlay h-100">
          <h6 class="drop">
            {{ vprops.name }}
          </h6>
        </div>
      </div>
    </router-link>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'VaultComponent',
  props: ['vprops'],
  setup(props) {
    return {
      profileVaults: computed(() => AppState.profileVaults),
      allVaults: computed(() => AppState.vaults)

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
img {
  height: 15em;
  width: 12em;
}
.drop {
  position: absolute;
  bottom: 5px;
}
h6 {
  color: white;
}

</style>
