<template>
  <div class="Profile container-fluid p-5">
    <div class="row">
      <div class="col-4">
        <img class="img-thumbnail rounded pic" :src="activeProfile.picture" alt="">
      </div>
      <div class="col-7">
        <div class="row">
          <h1> {{ activeProfile.name }}</h1>
          <div class="col-12">
            <h2>Vaults: {{ activeProfileVaults.length }}</h2>
          </div>
          <div class="col-12">
            <h2>Keeps: {{ activeProfileKeeps.length }} </h2>
          </div>
        </div>
      </div>
    </div>
    <!-- Button trigger modal -->

    <!-- Modal -->
    <div class="modal fade"
         id="VaultCenter"
         tabindex="-1"
         role="dialog"
         aria-labelledby="exampleModalCenterTitle"
         aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered " role="document">
        <div class="modal-content modal-border">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLongTitle">
              New Vault
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span class="text-danger" aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="form-group">
              <label for="" class="col-form-label">Title:</label>
              <input type="text" class="form-control" name="inputfields" v-model="state.newVault.name" placeholder="Title...">
            </div>
            <div class="form-group">
              <label for="" class="col-form-label">Image Url</label>
              <input type="text" class="form-control" name="inputfields" placeholder="Url..." v-model="state.newVault.img">
            </div>
            <div class="form-group">
              <label for="" class="col-form-label">Description</label>
              <input type="text" class="form-control" name="inputfields" placeholder="" v-model="state.newVault.description">
            </div>
            <div class="form-check-inline">
              <input class="form-check-input" type="checkbox" id="inlineCheckbox1" value="option2" v-model="state.newVault.isPublished">
              <label for="" class="col-form-label">Publish?</label>
            </div>
            <div>
            </div>
          </div>
          <div class="modal-footer">
            <button @click="createVault(state.newVault)" type="button" data-dismiss="modal" class="modal-create btn btn-primary">
              Create Vault
            </button>
          </div>
        </div>
      </div>
    </div>

    <!-- Modal -->
    <div class="modal fade"
         id="KeepCenter"
         tabindex="-1"
         role="dialog"
         aria-labelledby="exampleModalCenterTitle"
         aria-hidden="true"
    >
      <div class="moderate modal-dialog modal-dialog-centered " role="document">
        <div class="modal-content modal-border">
          <form action="sumit" id="keepform" @submit.prevent="createKeep(state.newKeep)">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLongTitle">
                New Keep
              </h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span class="text-danger" aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <div class="form-group">
                <label for="" class="col-form-label">Title:</label>
                <input type="text" class="form-control" name="inputfields" v-model="state.newKeep.name" placeholder="Title...">
              </div>
              <div class="form-group">
                <label for="" class="col-form-label">Image Url</label>
                <input type="text" class="form-control" name="inputfields" placeholder="Url..." v-model="state.newKeep.img">
              </div>
              <div class="form-group">
                <label for="" class="col-form-label">Description</label>
                <textarea v-model="state.newKeep.description" class="form-control" name="inputfields" cols="30" rows="6"></textarea>
              </div>
              <!-- <div class="form-group">
                <label for="" class="col-form-label">Tags:</label>
                <input type="text" class="form-control" name="inputfields" v-model="state.newKeep.tags" placeholder="Tags...">
              </div> -->
              <!-- <div class="form-check-inline">
                <input class="form-check-input" type="checkbox" id="inlineCheckbox1" value="option2" v-model="state.newKeep.isPublished">
                <label for="" class="col-form-label">Save as Draft?</label>
              </div> -->
              <div>
              </div>
            </div>
            <div class="modal-footer py-1">
              <button @click="createKeep(state.newKeep)" type="button" data-dismiss="modal" class="modal-create btn btn-primary">
                Create Keep
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
    <div class="row mt-5">
      <h1 class="subheader ml-4">
        Vaults
      </h1><button v-if="userProfile.id == activeProfile.id" data-target="#VaultCenter" data-toggle="modal" class="btn btn-sm btn-link">
        <h1>+</h1>
      </button>
    </div>
    <div id="vault-row" class="d-flex h100">
      <VaultComponent v-for="v in activeProfileVaults" :key="v.id" :vprops="v" />
    </div>
    <div class="row mt-5">
      <h1 class="subheader ml-4">
        Keeps
      </h1><button v-if="userProfile.id == activeProfile.id" data-toggle="modal" data-target="#KeepCenter" class="btn btn-sm btn-link">
        <h1>+</h1>
      </button>
      <div class="card-columns p-3">
        <ProfileKeep v-for="k in activeProfileKeeps" :key="k.id" :kprops="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { VaultComponent } from '../components/VaultComponent'
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
import { vaultService } from '../services/VaultsService'
import { keepService } from '../services/KeepService'
import { logger } from '../utils/Logger'

export default {
  name: 'Profile',
  props: ['kprops', 'vprops'],
  components: { VaultComponent },
  setup(props) {
    const route = useRoute()
    const state = reactive({
      newVault: {
        corn: AppState.userProfile.id
      },
      newKeep: {
        corn: AppState.userProfile.id
      }
    })
    onMounted(() => {
      profileService.getOneProfile(route.params.profileId)
      profileService.getProfileVaults(route.params.profileId)
      profileService.getProfileKeeps(route.params.profileId)
    })
    return {
      state,
      userProfile: computed(() => AppState.userProfile),
      activeProfile: computed(() => AppState.activeProfile),
      activeProfileKeeps: computed(() => AppState.activeProfileKeeps),
      activeProfileVaults: computed(() => AppState.activeProfileVaults),
      createVault(newVault) {
        // if (!newVault.isPublished) {
        //   newVault.isPublished = false
        // }
        state.newVault = {
          corn: AppState.userProfile.id
        }
        vaultService.createVault(newVault)
      },
      createKeep(newKeep) {
        logger.log('nk', newKeep)
        keepService.createKeep(newKeep)
      }

    }
  }
}
</script>

<style scoped>
img {
  max-width: 500px;
}
h1 {
  font-size: 5em;
}
#vault-row {
  white-space: nowrap;
  overflow-x: auto;
}
.pic {
width: 100%;
}
#plus {
  color:#55efc4
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
.modal-border {
  border: solid;
  border-color: #97bdb2;
}
#small-print {
  font-size: 10px;
  position: absolute;
  bottom: -1px;
}
.modal-create {
  background-color: #55efc4;
  border-color: #55efc4;
}
</style>
