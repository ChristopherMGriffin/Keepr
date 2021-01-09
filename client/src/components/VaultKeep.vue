<template>
  <div class="VaultKeep card mt-2 p-0">
    <div class="container p-0">
      <div>
        <img
          class="card-img"
          style="width: 100%; height: auto"
          :src="vkprops.img"
          alt="Card image cap"
        >
        <div class="ml-0 mb-0 p-0 text-white card-img-overlay h-100 d-flex flex-column justify-content-end">
          <a href="#" @click="getOne(vkprops.id)" class="text-white text-left" data-toggle="modal" :data-target="'#modelId' + vkprops.id">

            <p class="align-self-start mb-1 ml-1">
              {{ vkprops.name }}
            </p>
          </a>
          <i v-if="userProfile.id == activeVault.creatorId" aria-hidden="true" data-dismiss="modal" @click="deleteVaultKeep(vkprops)" class="fas fa-trash top-left   "></i>
          <router-link :to="{ name: 'Profile', params: { profileId: vkprops.creatorId} }">
            <!-- <i class="ml-5 fa fa-user-circle bottom-right" aria-hidden="true"></i> -->
            <img
              :src="vkprops.creator.picture"
              alt="user photo"
              height="15"
              class="rounded bottom-right"
            />
          </router-link>
          <p id="name" class="bottomer">
            {{ vkprops.creator.name }}
          </p>
        </div>
      </div>
      <div :id="'modelId' + vkprops.id"
           class="modal fade bd-example-modal-lg"
           tabindex="-1"
           role="dialog"
           aria-labelledby="myLargeModalLabel"
           aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered modal-lg">
          <div class="modal-content ">
            <div class="modal-body p-2">
              <div class="container-fluid ">
                <div class="row">
                  <div class="col-5 ">
                    <div class="row">
                      <img id="modal-image" :src="vkprops.img" alt="">
                    </div>
                  </div>
                  <div class="col-7">
                    <div class="row">
                      <div class="col-12">
                        <button type="button" class="close btn btn-lg" data-dismiss="modal" aria-label="Close">
                          <span class="text-danger" aria-hidden="true">&times;</span>
                        </button>
                      </div>
                    </div>
                    <div class="row">
                      <div class="pr-2 col-4 d-flex justify-content-end">
                        <p class="fade.in">
                          <i class="fas fa-eye    "></i>
                          {{ vkprops.views }}
                        </p>
                      </div>
                      <div class="col-3">
                        <p>
                          <img class="pl-4 clr center pb-1"
                               src="../assets/img/klogo.png"
                               height="20"
                          />
                          {{ vkprops.keeps }}
                        </p>
                      </div>
                      <div class="col-3 pl-0">
                        <p class="">
                          <i class="fas fa-project-diagram"></i>
                          {{ vkprops.shares }}
                        </p>
                      </div>
                    </div>
                    <div class="mb-3 header">
                      <div class="row">
                        <div class="ml-2 col-12">
                          <h1>{{ vkprops.name }}</h1>
                        </div>
                      </div>
                    </div>
                    <div class="row" id="modal-description">
                      <div class="col-12">
                        <p>{{ vkprops.description }}</p>
                      </div>
                    </div>

                    <div class="row border-top border-dark mt-3 justify-content-center mr-1">
                      <div class="p-1 col-12" id="tags">
                        <button class="btn btn-link">
                          tag 1
                        </button>
                        <button class="btn btn-link">
                          tag 2
                        </button>
                        <button class="btn btn-link">
                          tag 3
                        </button>
                        <button class="btn btn-link">
                          tag 4
                        </button>
                        <button class="btn btn-link">
                          tag 5
                        </button>
                        <button class="btn btn-link">
                          tag 6
                        </button>
                        <button class="btn btn-link">
                          tag 7
                        </button>
                        <button class="btn btn-link">
                          tag 8
                        </button>
                      </div>
                    </div>
                    <div id="" class="row  pl-0 justify-content-space-between">
                      <div class="col-3 pl-1">
                        <div>
                          <div class="btn-group btn-block dropup pl-0">
                            <button id="vaultdoor"
                                    @click="deleteVaultKeep(vkprops)"
                                    type="button"
                                    class="ml-0 btn border rounded dropdown-toggle"
                                    aria-haspopup="true"
                                    aria-expanded="false"
                                    data-dismiss="modal"
                            >
                              Remove from Vault
                            </button>
                            <div class="dropdown-menu">
                              <ul class="row p-0 m-0">
                                <li class="col-12">
                                  <button type="button" class="btn btn-block btn-smbtn-link" data-toggle="modal" data-target="#modelId">
                                    Create New
                                  </button>
                                </li>
                                <VaultMenuComponent v-for="vk in vaultKeeps" :key="vk.id" :vkprops="vk" />
                              </ul>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="col pt-2">
                        <i v-if="userProfile.id == vkprops.creatorId" id="trash" class="fas fa-trash fa-lg"></i>
                      </div>
                      <div class="col">
                        <span>
                          <img
                            :src="vkprops.creator.picture"
                            alt="user photo"
                            height="40"
                            class="rounded"
                          />
                        </span>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { computed, reactive } from 'vue'
import { keepService } from '../services/KeepService'
import { AppState } from '../AppState'
import VaultMenuComponent from './VaultMenuComponent.vue'
import { vaultService } from '../services/VaultsService'
export default {
  name: 'VaultKeep',
  props: ['kprops', 'vkprops'],
  setup(props) {
    const state = reactive({
      editedKeep: {}
    })
    return {
      state,
      vaultKeeps: computed(() => AppState.vaultKeeps),
      activeVault: computed(() => AppState.activeVault),
      userProfile: computed(() => AppState.userProfile),
      deleteVaultKeep(vk) {
        vaultService.deleteVaultKeep(vk)
      },
      editKeep(editedKeep) {
        keepService.editKeep(editedKeep)
      },
      getOne(id) {
        keepService.getOne(id)
      }
    }
  },
  components: { VaultMenuComponent }
}
</script>

<style lang="scss" scoped>

#modal-image {
  max-width: 20em;
  max-height: 30em;
}

i {
  color:#55efc4 ;
}
i:hover {
  transform: scale(1.5);
}

.clr {
  color:#55efc4 ;

}
#modal-description {
  max-height: 15em;
  overflow-y: auto;
}
#trash {
  color: gray;
}
#vaultdoor {
  color: #55efc4;
}
#tags {
  white-space: nowrap;
  overflow-x: auto;
  margin-bottom: 3px;
}
ul {
  list-style-type: none;
}
.bottom-right {
  position: absolute;
  bottom: 8px;
  right: 8px;
}
#card-bottom {
  position: absolute;
  bottom: 5px;
}
.bottomer {
  position: absolute;
  bottom: -14px;
  right: 5px;
}
 #name {
   font-size: 9px;
}
.bottom-right:hover {
  transform: scale(3);
}
.top-left {
  position: absolute;
  top: 5px;
  left: 5px
}

</style>
