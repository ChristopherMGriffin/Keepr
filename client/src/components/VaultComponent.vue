<template>
  <div class="m-1 VaultComponent">
    <!--Card image-->
    <div class="col container p-0">
      <img class="card-img" :src="vprops.img" alt="">
      <div class="card-img-overlay h-100">
         <i v-if="userProfile.id == vprops.creatorId" aria-hidden="true" data-dismiss="modal" @click="deleteVault(vprops.id)" class="fas fa-trash top-left text-secondary"></i>
        <router-link @click="getActiveVault(vprops.id)" :to="{ name: 'ActiveVault', params: { vaultId: vprops.id} }">
          <h6 class="drop">
            {{ vprops.name }}
          </h6>
        </router-link>
        <!-- <i v-if="userProfile.id == vprops.creatorId" @click="deleteVault(vprops.id)" class="upper-left fa fa-trash" aria-hidden="true"></i> -->
        <h6 class="text-light ml-5">
          {{ vprops.id }}
        </h6>
        <h6 class="text-light ">
          Is Published:  {{ vprops.isPublished }}
        </h6>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { vaultService } from '../services/VaultsService'
export default {
  name: 'VaultComponent',
  props: ['vprops'],
  setup(props) {
    return {
      userProfile: computed(() => AppState.userProfile),
      activeProfile: computed(() => AppState.activeProfile),
      profileVaults: computed(() => AppState.profileVaults),
      allVaults: computed(() => AppState.vaults),
      deleteVault(id) {
        vaultService.deleteVault(id)
      },
      getActiveVault(id) {
        vaultService.getOne(id)
        vaultService.getVaultKeeps(id)
      }

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
.upper-left {
  position: absolute;
  top: 8px;
  left: 5px;
  color: red;
}
.upper-left:hover {
  transform: scale(3);
}
>bottom-right {
  position: absolute;
  bottom: 5px;
  right: 5px;
}
.top-left {
  position: absolute;
  top: 5px;
  left: 5px
}
i:hover {
  transform: scale(1.5);
}

</style>
