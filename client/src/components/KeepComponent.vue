<template>
  <div class="keep card mt-2 p-0">
    <div class="container p-0">
      <div>
        <img
          class="card-img"
          style="width: 100%; height: auto"
          :src="kprops.img"
          alt="Card image cap"
        >
        <div class="ml-0 mb-0 p-0 text-white card-img-overlay h-100 d-flex flex-column justify-content-end">
          <div v-if="userProfile.id == kprops.creatorId && $route.name !== 'ActiveVault'" @click="deleteKeep(kprops.id)" class="trash justify-content-center d-flex rounded p-1">
            <i aria-hidden="true" data-dismiss="modal" class="fas fa-trash fa-sm text-secondary"></i>
          </div>

          <div v-if="userProfile.id == activeVault.creatorId && $route.name == 'ActiveVault'" @click="deleteVaultKeep(kprops)" class="trash justify-content-center d-flex rounded p-1">
            <i aria-hidden="true" data-dismiss="modal" class="fas fa-trash fa-sm text-secondary"></i>
          </div>

          <a href="#" @click="getOne(kprops.id)" class="text-white text-left" data-toggle="modal" :data-target="'#modelId' + kprops.id">
            <div>
              <h6 class=" p-1 rounded mx-auto drop text-secondary d-flex justify-content-center">
                {{ kprops.name }}
              </h6>
            </div>
          </a>
          <router-link :to="{ name: 'Profile', params: { profileId: kprops.creatorId} }">
            <img
              :src="kprops.creator.picture"
              alt="user photo"
              height="20"
              class="rounded bottom-right"
              v-show="$route.name !== 'Profile'"
            />
          </router-link>
        </div>
      </div>
      <div :id="'modelId' + kprops.id"
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
                    <div class="row center">
                      <img class="" style="width: auto; height: 100%" id="modal-image" :src="kprops.img" alt="">
                    </div>
                  </div>
                  <div class="col-7 mb-0 pb-0">
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
                          {{ activeKeep.views }}
                        </p>
                      </div>
                      <div class="col-3">
                        <p>
                          <img class="pl-4 clr center pb-1"
                               src="../assets/img/klogo.png"
                               height="20"
                          />
                          {{ activeKeep.timesKept }}
                        </p>
                      </div>
                      <div class="col-3 pl-0">
                        <p class="">
                          <i class="fas fa-project-diagram"></i>
                          {{ activeKeep.shares }}
                        </p>
                      </div>
                    </div>
                    <div class="mb-3 header">
                      <div class="row">
                        <div class="ml-2 col-12">
                          <h1>{{ kprops.name }}</h1>
                        </div>
                      </div>
                    </div>
                    <div class="row" id="modal-description">
                      <div class="col-12">
                        <p>{{ kprops.description }}</p>
                      </div>
                    </div>
                    <div id="card-bottom" class="row border-top pt-2 pl-0">
                      <div class="col-2 pl-1 mr-5">
                        <div>
                          <div class="btn-group btn-block dropup pl-0">
                            <button id="vaultdoor"
                                    type="button"
                                    class="ml-0 my-0 btn border rounded dropdown-toggle"
                                    data-toggle="dropdown"
                                    aria-haspopup="true"
                                    aria-expanded="false"
                                    :disabled="!user.isAuthenticated ? '' : disabled"
                            >
                              Add To Vault
                            </button>
                            <div class="dropdown-menu">
                              <ul class="row p-0 m-0">
                                <li class="col">
                                  <p class="text-dark">
                                    Private
                                  </p>
                                </li>
                                <li class="col">
                                  <p class="text-success">
                                    Public
                                  </p>
                                </li>
                                <li v-for="v in userVaults" :key="v.id" :vprops="v" class="VaultMenuComponent col-12 d-flex justify-content-center">
                                  <router-link :to="{ name: 'ActiveVault', params: { vaultId: v.id} }">
                                    <button
                                      type="button"
                                      class="btn btn-sm btn-lg btn-link"
                                      @click="addToVault(v.id)"
                                      data-dismiss="modal"
                                    >
                                      <p class="pl-0 text-success" v-if="v.isPublished">
                                        {{ v.name }}
                                      </p>
                                      <p class="pl-0 text-dark" v-else>
                                        {{ v.name }}
                                      </p>
                                    </button>
                                  </router-link>
                                </li>
                              </ul>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="col-5 pt-2">
                      </div>
                      <div class="col-3 pl-5 pr-0 mr-0 d-flex justify-content-end">
                        <span>
                          <img
                            :src="kprops.creator.picture"
                            alt="user photo"
                            height="40"
                            class="rounded move-right mb-3"
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
import { profileService } from '../services/ProfileService'
import { vaultService } from '../services/VaultsService'
export default {
  name: 'Keep',
  props: ['kprops', 'vprops', 'vkprops'],
  setup(props) {
    const state = reactive({
      editedKeep: {}
    })
    return {
      state,
      profileVaults: computed(() => AppState.profileVaults),
      user: computed(() => AppState.user),
      userProfile: computed(() => AppState.userProfile),
      activeKeep: computed(() => AppState.activeKeep),
      userVaults: computed(() => AppState.userVaults),
      activeVault: computed(() => AppState.activeVault),
      deleteKeep(id) {
        keepService.deleteKeep(id)
      },
      editKeep(editedKeep) {
        keepService.editKeep(editedKeep)
      },
      getOne(id) {
        keepService.getOne(id)
      },
      getActiveProfile(id) {
        profileService.getOneProfile(id)
      },
      addToVault(vId) {
        vaultService.createVaultKeep(vId)
      },
      deleteVaultKeep(vk) {
        vaultService.deleteVaultKeep(vk)
      }
    }
  },
  components: {}
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
.clr {
  color:#55efc4;
}
#modal-description {
  max-height: 15em;
  overflow-y: auto;
}

#vaultdoor {
  color: #55efc4;
}
ul{
  list-style-type: none;
}
.bottom-right {
  position: absolute;
  bottom: 5px;
  right: 8px;
  font-size: 7;
}
#card-bottom {
  position: absolute;
  bottom: 0%;
  width: 100%
}
.bottomer {
  position: absolute;
  bottom: -15px;
  right: 5px;
}
.bottom-right:hover {
  transform: scale(1.5);
}
.move-right{
  position: absolute;
  right: -12px;
}
.trash{
  background-color: white;
  width: 20px;
  position: absolute;
  left: 5px;
  top: 5px;
}
.trash:hover{
  cursor: pointer;
}
.drop {
  position: absolute;
  bottom: -3px;
  left: 4px;
  background-color: white;
}
</style>
